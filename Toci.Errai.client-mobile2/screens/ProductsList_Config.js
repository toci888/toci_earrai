
export const typesOfSearch = [
    "DimA",
    "DimB",
    "Thickness",
    "Width",
    "OD",
    "DIA", // idx 5
    "Type",
    "Metric",
    "Id",
    "Product Code Short",
    "Description", // idx 10
]

const selectedIndexOfTypeOfSearchForWorksheet = {
    1: [2],
    2: [2],
    3: [0, 1],
    4: [3], // flts ??
    5: [0, 1], // ??
    6: [6, 7],
    7: [6, 9, 10],
    8: [4],
    9: [4, 9], // TODO whatsupp
}

export function getAvailableTypeForWorksheet(worksheetId) {
    const x = selectedIndexOfTypeOfSearchForWorksheet[worksheetId]
    console.log(x);
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
        //console.log(x);
        return x.includes(index)
    })
    console.log(response)
    return response
}



