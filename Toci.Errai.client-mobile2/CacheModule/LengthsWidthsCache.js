

export default class LengthsWidthsCache
{
    static categoryPrefix;
    static CodesDimensions = 
    {
        codes: [ { code: 'PL', kind: 1 }, 
        { code: 'PLCHQ', kind: 1 }, 
        { code: 'HD', kind: 1 }, 
        { code: 'GS', kind: 1 }, 
        { code: 'ALSH', kind: 1 }, 
        { code: 'ALCHQ', kind: 1 }, 
        { code: 'MSH', kind: 1 }, 
        { code: 'EX_MET', kind: 1 }, 
        { code: 'SHS', kind: 2 }, 
        { code: 'RHS', kind: 2 }, 
        { code: 'PFC', kind: 2 }, 
        { code: 'UB', kind: 2 }, 
        { code: 'UC', kind: 2 }, 
        { code: 'IPE', kind: 2 }, 
        { code: 'EA', kind: 2 }, 
        { code: 'UA', kind: 2 }, 
        { code: 'TS', kind: 2 }, 
        { code: 'CHS', kind: 2 }, 
        { code: 'GCHS', kind: 2 }, 
        { code: 'FL', kind: 2 }, 
        { code: 'FLB', kind: 2 }, 
        { code: 'RB_BLK', kind: 2 }, 
        { code: 'RB_BRI', kind: 2 }, 
        { code: 'SQ_BLK', kind: 2 }, 
        { code: 'SQ_BRI', kind: 2 }, 
        { code: 'HB', kind: 2 }, 
        { code: 'F_BH', kind: 2 }, 
        { code: 'F_PB', kind: 2 }, 
        { code: 'F_TB', kind: 2 }, 
        { code: 'F_PS', kind: 2 }, 
        { code: 'F_LL', kind: 2 }, 
        { code: 'F_TS', kind: 2 }, 
        { code: 'F_LR', kind: 2 }, 
        { code: 'F_CF', kind: 2 }, 
        { code: 'F_BT', kind: 2 }, 
        { code: 'F_FT', kind: 2 }, 
        { code: 'F_PL', kind: 2 }, 
        { code: 'F_FLB', kind: 2 }, 
        { code: 'F_YS', kind: 2 }, 
        { code: 'F_SP', kind: 2 }, 
        { code: 'PF_BH', kind: 2 }, 
        { code: 'PF_PB', kind: 2 }, 
        { code: 'PF_TB', kind: 2 }, 
        { code: 'PF_PS', kind: 2 }, 
        { code: 'PF_LL', kind: 2 }, 
        { code: 'PF_TS', kind: 2 }, 
        { code: 'PF_LR', kind: 2 }, 
        { code: 'PF_CF', kind: 2 }, 
        { code: 'PF_CA', kind: 2 }, 
        { code: 'PF_BT', kind: 2 }, 
        { code: 'PF_FT', kind: 2 }, 
        { code: 'PF_PL', kind: 2 }, 
        { code: 'PF_FLB', kind: 2 }, 
        { code: 'PF_YS', kind: 2 }, 
        { code: 'PF_SP', kind: 2 }, 
        { code: 'RAM_', kind: 2 }, 
        { code: 'PAI', kind: 2 }, 
        { code: 'CON', kind: 2 } ]
    }

    static GetCodeDimentionKind(code)
    {
        for(var i = 0; i < LengthsWidthsCache.CodesDimensions.codes.length; i++)
        {
            if (LengthsWidthsCache.CodesDimensions.codes[i].code == code)
            {
                return LengthsWidthsCache.CodesDimensions.codes[i].kind;
            }
        }

        return 1;
    }

    static LastUsedWidth = {};
    static LastUsedLength = {};

    static CacheWidth = (worksheetId, width) =>  {
        LengthsWidthsCache.LastUsedWidth[worksheetId] = width;
    }

    static CacheLength = (worksheetId, width) =>  {
        LengthsWidthsCache.LastUsedLength[worksheetId] = width;
        console.log('LastUsedLength cache width', LengthsWidthsCache.LastUsedLength);
    }

    static GetCachedWidth = (worksheetId) =>  {
        return LengthsWidthsCache.LastUsedWidth[worksheetId];
    }

    static GetCachedLength = (worksheetId) =>  {
        console.log('LastUsedLength get', LengthsWidthsCache.LastUsedLength, LengthsWidthsCache.LastUsedLength[worksheetId]);
        return LengthsWidthsCache.LastUsedLength[worksheetId];
    }
}