import NetInfo from '@react-native-community/netinfo';

export class ConnectionService {

    isConnected = true

    testPermanentDisconnect = false

    isStartedInterval = false

    disconnectedAt = null

    lastIntervalAt = new Date()

    cacheData = [
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


    checkConnect() {
        NetInfo.fetch().then(state => {
            console.log('Is connected?', state.isConnected, "cacheData: ", this.cacheData)

            if(this.testPermanentDisconnect) {




                return
            } else if(!this.isConnected) {

                if(state.isConnected) {
                    this.flushCache()
                } else {
                    // still discon
                }


            } else if(this.isConnected) {


                if(!state.isConnected) {
                    console.log("Disconnected!!!")
                    disconnectedAt = new Date()
                } else { // still con

                    // GET getNewRecordsFromContentHistory/{lastIntervalAt.toString()}
                    // .then( data => {
                    //      if( data ) { add rows to table or update }

                    this.lastIntervalAt = new Date()
                }

            }

            this.isConnected = state.isConnected

            return state.isConnected
        })
    }

}