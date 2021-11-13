
export const typesOfSearch = [
    "DimA",
    "DimB",
    "Thickness",
    "Width",
    "OD",

]

const selectedIndexOfTypeOfSearchForWorksheet = {
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
    return selectedIndexOfTypeOfSearchForWorksheet[worksheetId]
}

function getDtoObject(worksheetId_, type_, value_, skip_) {
    return {
        WorksheetId: worksheetId_,
        name: type_,
        Value: value_,
        skip: skip_,
    }
}

export function createFilterDto(worksheetId_, type_, value_, skip_) {

    return getDtoObject(worksheetId_, type_, value_, skip_)

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





