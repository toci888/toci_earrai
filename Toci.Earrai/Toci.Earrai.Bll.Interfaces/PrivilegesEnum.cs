namespace Toci.Earrai.Bll.Interfaces
{
    public enum PrivilegesEnum
    {
        User = 1,
        O = 2,
        P = 4,
        A = 8,
        Office = User | O,
        Pc = Office | P,
        Admin = Pc | A
    }
}