using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.SQLTable;

namespace CheckROHS
{
    public struct MtlRohs
    {
        public string PartNum;
        public bool Rohs;
    }

    public class PartBOM
    {
        //private bool hasParent = false;
        //private bool hasChildren = false;
        public bool bomRohs = true;

        public string PartNum;
        public string RevNum;
        //public bool InActive = false;

        private List<string> partBom = new List<string>();
        public List<MtlRohs> endMtls = new List<MtlRohs>();
        public List<PartBOM> subs = new List<PartBOM>();

        public PartBOM(string pn, string ver)
        {
            this.PartNum = pn;
            this.RevNum = ver;

            InitBOM();
            SortMtls();
        }

        public bool GetBomRohsFlag()
        {
            return this.bomRohs;
        }

        private bool InitBOM()
        {
            bool ret = false;

            // Need to handle a part number contains '='
            EpicorVPartWhereUsedFGAllRev pbom = new EpicorVPartWhereUsedFGAllRev(this.PartNum, this.RevNum);
            partBom = pbom.GetUniqueParts();

            return ret;
        }

        private void SortMtls()
        {
            EpicorVPartSearch evps = new EpicorVPartSearch();
            EpicorPartRev eprev = new EpicorPartRev();

            foreach (string anitem in partBom)
            {
                if (anitem[0] == '%') continue;

                bool rohsTag;
                bool subTag = evps.CheckSubRohs(anitem, out rohsTag);
                if (!subTag)
                {
                    MfgDataSubPart mdsp = new MfgDataSubPart();
                    subTag = mdsp.CheckPartExist(anitem);
                }

                if ( subTag )
                {
                    string partNum = anitem; ;
                    string pRev = "";
                    // find the version first
                    if (anitem.IndexOf("=") == -1)
                    {
                        pRev = eprev.GetRevision(anitem);
                    }
                    else
                    {
                        string pn = "";
                        DBHelper.Util.ExtractPartInfo(anitem, ref pn, ref pRev);
                    }

                    PartBOM pb = new PartBOM(partNum, pRev);
                    if (!pb.GetBomRohsFlag())
                    {
                        this.bomRohs = false;
                    }
                    subs.Add(pb);
                }
                else
                {
                    MtlRohs mr = new MtlRohs();
                    mr.PartNum = anitem;
                    if (rohsTag)
                    {
                        mr.Rohs = true;
                    }
                    else
                    {
                        mr.Rohs = false;
                        this.bomRohs = false;
                    }
                    endMtls.Add(mr);
                }
            } // foreach
        } // SortMtls()

    } // class
}
