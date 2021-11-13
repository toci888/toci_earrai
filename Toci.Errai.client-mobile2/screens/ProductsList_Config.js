
export const typesOfSearch = [
    "DimA",
    "DimB",
    "Thickness",
    "Width",
    "OD",

]

const selectedTypeOfSearchForWorksheet = {
    1: 2,
    2: 2,
    3: 0,
    4: 3, // flts ??
    5: 0, // ??
    6: 0,  // chanBms  ??
    7: 0,
    8: 4,
    9: 0,
}

export function getAvailableTypeForWorksheet(worksheetId) {
    return selectedTypeOfSearchForWorksheet[worksheetId]
}

function getDtoObject(worksheetId_, type_) {
    return {
        WorksheetId: worksheetId_,
        Name: type_,
    }
}

export function createFilterDto(worksheetId, type) {

    return getDtoObject(worksheetId, type)

    /*if([3,5,6,7].includes(worksheetId)) {

        return {
            ...getObject(worksheetId, skip),
            DimA: phrase[0],
            DimB: phrase[1],
        }

    } else if([1,2].includes(worksheetId)) {

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

    }*/

}





