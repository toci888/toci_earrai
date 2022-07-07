
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
    "Category", //11
    "Length",
    "Width",
            "Balance",
            "Area",
            "Stock take value"
]

const selectedIndexOfTypeOfSearchForWorksheet = {
    1: [2, 11, 12, 13, 15],
    2: [2, 11, 12, 13, 15],
    3: [3, 12, 11, 12, 13, 15],
    4: [11, 12, 13, 15], // chan ??
    5: [0, 1, 11, 12, 13, 15], // ??
    6: [2, 11, 12, 13, 15],
    7: [2, 3, 11, 12, 13, 15],
    8: [4, 11, 12, 13, 15],
    9: [2, 11, 12, 13, 15], // TODO whatsupp
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



