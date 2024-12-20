﻿using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Tests.Import
{
    public class ImportManager
    {
        // oper na excel
        //fszyskie instancje importow - ich odpalenie

        protected Dictionary<string, ImportBase> Imports = new Dictionary<string, ImportBase>()
        {
            { "PLT & SHEET", new PltSheetImport() },
            { "Alum", new AlumImport() },
            { "Msh & Exp.Metal", new MshExpMetal() },
            { "Chan & Bms", new ChanBms() },
            { "Angles+T", new AnglesT() },
            { "FLTS", new FLTS() },
            { "Tube_CHS", new TubeCHS() },
            { "RHS", new RHS() },
            { "Rnds_Sqrs_HolBar", new RndsSqrsHolBar() }
        };
                                                     //pltsheet, alum, etc
        public virtual void EntireImport(Dictionary<string, List<List<string>>> excelContents)
        {
            foreach (KeyValuePair<string, List<List<string>>> item in excelContents)
            {
                //item.Value.Text
                if (Imports.ContainsKey(item.Key))
                    Imports[item.Key].ImportProduct(item.Key, item.Value);
            }
        }

    }
}
