
export const typesOfSearch = [
    "Dimension A",
    "Dimension B",
    "Thickness",
    "Width",
    "OD",

]

const typeOfSearchForWorksheet = {
    1: 0,
    2: 3,
    5: 0,
    6: 0,
    7: 0,
    8: 4,
    9: 0,
}

export function getSelectedTypeForWorksheet(worksheetId) {
    return typeOfSearchForWorksheet[worksheetId]
}









