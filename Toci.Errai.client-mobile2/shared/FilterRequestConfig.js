
function getObject(worksheetId, skip) {

    const x = {
        WorksheetId: worksheetId,
        Skip: skip,
        Name: "",
    }

    return x

}

export function FilterRequestConfig(worksheetId, phrase, skip) {

    if([1,3,5,6,7].includes(worksheetId)) {

        return {
            ...getObject(worksheetId, skip),
            DimA: phrase[0],
            DimB: phrase[1],
        }

    } else if(worksheetId == 2) {

        return {
            ...getObject(worksheetId, skip),
            Thickness: phrase
        }

    } else if(worksheetId == 4) {

        return {
            ...getObject(worksheetId, skip),
            Width: phrase
        }

    } else if(worksheetId == 8) {

        return {
            ...getObject(worksheetId, skip),
            OD: phrase
        }

    }

}