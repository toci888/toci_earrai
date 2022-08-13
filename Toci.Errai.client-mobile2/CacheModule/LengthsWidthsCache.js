

export default class LengthsWidthsCache
{
    static LastUsedWidth = {};
    static LastUsedLength = {};

    static CacheWidth = (worksheetId, width) =>  {
        LengthsWidthsCache.LastUsedWidth[worksheetId] = width;
    }

    static CacheLength = (worksheetId, width) =>  {
        LengthsWidthsCache.LastUsedLength[worksheetId] = width;
    }

    static GetCachedWidth = (worksheetId) =>  {
        return LengthsWidthsCache.LastUsedWidth[worksheetId];
    }

    static GetCachedLength = (worksheetId) =>  {
        LengthsWidthsCache.LastUsedLength[worksheetId];
    }
}