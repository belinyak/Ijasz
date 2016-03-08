namespace Ijasz2.Nyomtatas.Seged {
    public static class DokumentumTipus {
        public static class Eredmenylap {
            public static class Verseny {
                public const string Teljes = "VersenyTeljes";
                public const string MISZ = "VersenyMISZ";
                public const string Egyesulet = "VersenyEgyesulet";
                public const string Reszletes = "VersenyReszletes";
            }
            public static class VersenySorozat {
                public const string Teljes = "VersenySorozatTeljes";
                public const string MISZ = "VersenySorozatMISZ";
                public const string Egyesulet = "VersenySorozatEgyesulet";
                public const string Reszletes = "VersenySorozatReszletes";
            }
        }
        public static class Startlista {
            public const string NevezesiLista = "NevezesiLista";
            public const string HianyzokLista = "HianyzokLista";
            public const string CsapatLista = "CsapatLista";
            public const string BeiroLap = "BeiroLap";
        }
        public static class Oklevel {
            public static class Verseny {
                public const string Oklevel = "Oklevel";
            }
        }
    }
}
