


export function FilterRequestConfig(worksheetId, phrase, skip) {

    if(worksheetId == 1) {

        return {
            WorksheetId: 1,
            Skip: skip,
            Name: "whatHere??",
            Thickness: phrase
        }

    } else if(worksheetId == 3) {

        return {
            WorksheetId: 3,
            Skip: skip,
            Name: "whatHere??",
            DimA: phrase[0],
            DimB: phrase[1]
        }

    }

}

    /*
        public int WorksheetId { get; set; }
        public int Skip { get; set; }
        public string Name { get; set; }
        public double? Thickness { get; set; }
    */