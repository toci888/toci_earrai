
export const typesOfSearch = [
    "DimA",
    "DimB",
    "Thickness",
    "Width",
    "OD",
    "DIA",

]

const selectedIndexOfTypeOfSearchForWorksheet = {
    1: [2],
    2: [2],
    3: [0, 1],
    4: [3], // flts ??
    5: [0, 1], // ??
    6: [0, 1, 2, 3, 4],  // chanBms  ??
    7: [0, 1, 2, 3, 4],
    8: [4],
    9: [0, 1, 2, 3, 4, 5], // TODO whatsupp
}

export function getAvailableTypeForWorksheet(worksheetId) {
    return selectedIndexOfTypeOfSearchForWorksheet[worksheetId]
}

function getDtoObject(worksheetId_, type_, value_) {
    return {
        WorksheetId: worksheetId_,
        name: type_,
        Value: value_,
    }
}

export function createFilterDto(worksheetId_, type_, value_) {

    return getDtoObject(worksheetId_, type_, value_)

}

export function getTypesOfSearchForWorksheet(worksheetId_) {
    let response = typesOfSearch.filter( (item, index) => {
        let x = getAvailableTypeForWorksheet(worksheetId_)

        return x.includes(index)
    })

    return response
}



