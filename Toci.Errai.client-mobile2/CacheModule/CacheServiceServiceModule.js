import NetInfo from '@react-native-community/netinfo';
import { environment } from '../environment';

export class ConnectionService {


    static nowContentData = {
        nowWorkbookId: null,
        nowWorksheetId: null,
        nowRowIndex: null
    }

    setNowWorkbookId(id) { ConnectionService.nowContentData.nowWorkbookId = id }
    getNowWorkbookId = () => ConnectionService.nowContentData.nowWorkbookId

    setNowWorksheetId(id) { ConnectionService.nowContentData.nowWorksheetId = id }
    getNowWorksheetId = () => ConnectionService.nowContentData.nowWorksheetId

    setRowIndex(index) { ConnectionService.nowContentData.nowRowIndex = index }
    getRowIndex = () => ConnectionService.nowContentData.nowRowIndex



    isConnected = true

    testPermanentDisconnect = false

    static isStartedInterval = false

    static intervalObject = null

    disconnectedAt = null

    lastIntervalAt = new Date()

    static dateToUpdate = []

    static cacheData = [

        // edit one worksheets or many

        /*{ workbookId: 1, workSheetName: "Arkusz1", row: 0, column: 0, value: "DUPA" }*/

        /*{ workbookId: 1, workSheetName: "Arkusz1", row: 0, column: 0, value: "DUPA" },
        { workbookId: 3, workSheetName: "Arkusz2", row: 6, column: 4, value: "DUPA2" },*/
    ]


    disconnect() {
        if(!this.testPermanentDisconnect) {
            this.testPermanentDisconnect = true
            this.isConnected = false
            console.log("DISCONNECTED")
            this.disconnectedAt = new Date()
        } else {
            this.testPermanentDisconnect = false
            //this.isConnected = true
            console.log("CONNECTED BACK")
            this.disconnectedAt = null
        }

    }

    /*setTestConnection = () => {
        this.testPermanentDisconnect = !this.testPermanentDisconnect
    }*/

    isConnectedFunc = () => {
        if(this.testPermanentDisconnect) {
            return false
        } else {
            return this.isConnected
        }
    }


    addDataToCache(object_) {
        /*console.log(object_);
        let x = ConnectionService.cacheData.filter( x =>
            x.Idworksheet == ConnectionService.nowContentData.nowWorksheetId &&
            x.IdUser ==  1 &&
            x.rowindex == object_.rowindex)

        if(x.length > 0) return*/

        ConnectionService.cacheData.push(object_)
    }

    updateRecord(ProductsList) {
        // fetch(environment.apiUrl + "api/WorksheetContent/", {
        //     method: "PUT",
        //     body: JSON.stringify(ProductsList) // Worksheetcontent
        // })
        // .then( response => response.json() )
        // .then( response => {
        //     console.log(response)
        // })
    }

    flushCache() {
        if(ConnectionService.cacheData.length == 0) {
            console.log("NO DATA IN CACHE. NOTHING TO UPDATE ON SERVER");
            return
        }

        console.log("Flush cache data to API");


        fetch(environment.apiUrl + "api/AreaQuantity/PostAreaQuantities", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(ConnectionService.cacheData) // arequantity
        })
        .then( response => {
            console.log(response)
            ConnectionService.cacheData = []
        })
        .catch(error => {
            console.log(error)
        })

        /*fetch(environment.apiUrl + "api/WorksheetContent/flushCache", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
              },

            body: JSON.stringify(ConnectionService.cacheData)
        })
        .then( response => response.json() )
        .then( response => { console.log(response) })
        .catch( error => { console.log(error) } )*/


        //this.getDataFromNow()
    }



    getDataFromNow() {
        console.log("Get updated data from API")
        //let d = JSON.stringify( new Date().toString() )
        let d = new Date()
        let x = {
            year: d.getFullYear(),
            month: d.getMonth(),
            day: d.getDate(),
            hour: d.getHours(),
            minute: d.getMinutes(),
            second: d.getSeconds(),
        }

        console.log(d)
        d = {dateTime: d}
        fetch(environment.apiUrl + "api/WorksheetContent/GetIncreaseWorksheetcontents", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(x)
        })
        .then( response => response.json() )
        .then( response => {

            if(response.length > 0) {
                this.compareDataFromAPI(response)
            }
        })

    }

    compareDataFromAPI(responseAPI) {
        // COMPARE
    }

    getDataFromTime_Disconnected() {

        // fetch(environment.apiUrl + "api/Workbook/get/GetIncreaseWorksheetcontents" + this.disconnectedAt)
        //     .then( response => response.json() )
        //     .then( response => {
        //         this.compareDataFromAPI("dataFromAPI")
        //         // if( data ) { add rows to table or update }
        // })
    }

    getDataFromTime_Interval() {

        // fetch(environment.apiUrl + "api/Workbook/get/GetIncreaseWorksheetcontents" + this.lastIntervalAt)
        //     .then( response => response.json() )
        //     .then( response => {
        //         this.compareDataFromAPI("dataFromAPI")
        //         // if( data ) { add rows to table or update }
        // })
    }

    checkConnect() {
        NetInfo.fetch().then(state => {
            if(this.testPermanentDisconnect) {
                console.log('Is connected?', false, ConnectionService.cacheData)

                return
            }

            //console.log('Is connected?', state.isConnected, "cacheData: ", ConnectionService.cacheData)
            //console.log(this.nowContentData);

            if(!this.isConnected) {

                if(state.isConnected) {
                    this.flushCache()

                    this.disconnectedAt = null
                } else {

                }


            } else if(this.isConnected) {


                if(!state.isConnected) {
                    console.log("Disconnected!!!")
                    this.disconnectedAt = new Date()
                } else { // still con

                    this.getDataFromTime_Interval()

                    this.lastIntervalAt = new Date()
                }

            }

            this.isConnected = state.isConnected

            return state.isConnected
        })
    }

}