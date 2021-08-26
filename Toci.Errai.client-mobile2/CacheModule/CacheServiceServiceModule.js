import NetInfo from '@react-native-community/netinfo';

export class ConnectionService {



    nowContentData = {
        worksheetId: null
    }

    isConnected = true

    testPermanentDisconnect = false

    static isStartedInterval = false

    static intervalObject = null

    disconnectedAt = null

    lastIntervalAt = new Date()

    static cacheData = [

        // edit one worksheets or many

        /*{ workbookId: 1, workSheetName: "Arkusz1", row: 0, column: 0, value: "DUPA" }*/

        /*{ workbookId: 1, workSheetName: "Arkusz1", row: 0, column: 0, value: "DUPA" },
        { workbookId: 3, workSheetName: "Arkusz2", row: 6, column: 4, value: "DUPA2" },*/
    ]



    disconnect() {
        console.log("DISCONNECTED")
        this.testPermanentDisconnect = false
        disconnectedAt = new Date()
    }

    isConnectedFunc = () => this.isConnected


    addDataToCache(object_) {
        this.cacheData.push(object_)
    }
//


    flushCache() {
        if(this.cacheData.length == 0) {
            console.log("NO DATA IN CACHE. NOTHING TO UPDATE ON SERVER");
            return
        }


        console.log("Flush cache data to API");
        // foreach(x data in cacheData)
        //    put(endpointToAddDataToDatabase_API, x)

        // "POST api/localhost/addCollection, cacheDataCollection"

        this.cacheData = []

        this.getDataFromDisconnectedTimestamp()
    }



    getDataFromDisconnectedTimestamp() {
        console.log("Get updated data from API")
        // GET api/localhost/getAddedDataFromTime/{disconnectedAt})
        // .then() {
            this.compareDataFromAPI("dataFromAPI")
        // }
    }

    compareDataFromAPI(data) {

    }

    getDataFromTime_Disconnected() {

        fetch("https://localhost:44326/api/Workbook/get/GetIncreaseWorksheetcontents" + this.disconnectedAt)
            .then( response => response.json() )
            .then( response => {

                // if( data ) { add rows to table or update }
        })
    }

    getDataFromTime_Interval() {

        fetch("https://localhost:44326/api/Workbook/get/GetIncreaseWorksheetcontents" + this.lastIntervalAt)
            .then( response => response.json() )
            .then( response => {

                // if( data ) { add rows to table or update }
        })
    }

    checkConnect() {
        NetInfo.fetch().then(state => {
            console.log('Is connected?', state.isConnected, "cacheData: ", this.cacheData)

            if(this.testPermanentDisconnect) {




                return
            } else if(!this.isConnected) { // already disconn

                if(state.isConnected) { // now connected
                    this.flushCache()

                    //this.getDataFromTime_Disconnected()

                    this.disconnectedAt = null
                } else {
                    // still discon
                }


            } else if(this.isConnected) { // already conn


                if(!state.isConnected) {
                    console.log("Disconnected!!!")
                    disconnectedAt = new Date()
                } else { // still con

                    //this.getDataFromTime_Interval()

                    this.lastIntervalAt = new Date()
                }

            }

            this.isConnected = state.isConnected

            return state.isConnected
        })
    }

}