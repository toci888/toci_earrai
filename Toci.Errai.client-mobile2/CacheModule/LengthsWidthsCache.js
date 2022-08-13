

export default class LengthsWidthsCache
{
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