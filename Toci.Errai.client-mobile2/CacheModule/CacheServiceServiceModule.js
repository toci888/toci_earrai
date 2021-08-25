import NetInfo from '@react-native-community/netinfo';

export class ConnectionService {

    isConnected = false;
    isStartedInterval = false;

    cacheData = [
        /*{
            workbookId: 1,
            workSheetName: "Arkusz1",
            row: 0,
            column: 0,
            value: "DUPA"
        },
        {
            workbookId: 3,
            workSheetName: "Arkusz2",
            row: 6,
            column: 4,
            value: "DUPA2"
        },*/

    ]

    disconnect() {
        console.log("DISCONNECTED");
        this.isConnected = false
    }

    isConnectedFunc() {
        return this.isConnected ? true : false
    }

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

        this.cacheData = []

        this.getDataFromDisconnectedTimestamp()
    }



    getDataFromDisconnectedTimestamp() {
        console.log("Get updated data from API");
        // get(endpointToGetDataFromDatabase_API/nowTimestamp)
        // .then() {
            this.compareDataFromAPI("dataFromAPI")
        // }
    }

    compareDataFromAPI(data) {
        console.log("CO TUTAJ ???????");
    }


     checkConnect() {
        NetInfo.fetch().then(state => {
            console.log('Is connected?', state.isConnected);
            console.log(this.cacheData)

            if(!this.isConnected) {

                if(state.isConnected) {
                    this.flushCache()
                }


            } else if(this.isConnected) {
                console.log("Disconnected!!!");
            }

            this.isConnected = state.isConnected

            return state.isConnected;
          })
    }


}