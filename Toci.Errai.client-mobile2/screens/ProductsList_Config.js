
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
    "Category",
    "Length"
]

const selectedIndexOfTypeOfSearchForWorksheet = {
    1: [2, 11],
    2: [2, 11],
    3: [3, 12, 11],
    4: [11], // chan ??
    5: [0, 1, 11], // ??
    6: [2, 11],
    7: [2, 3, 11],
    8: [4, 11],
    9: [2, 11], // TODO whatsupp
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



