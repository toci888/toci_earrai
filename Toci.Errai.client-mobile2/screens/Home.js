import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Text, View, TextInput, Button } from 'react-native'
import { ScrollView } from 'react-native-gesture-handler'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import { testColumn } from '../DbModule/sqLite'


export default function Home( { navigation }) {

    // checkConnected().then(res=> {
    //     setConnectStatus(res)
    // })

    const [connectService, setconnectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [apiConnect, setapiConnect] = useState(false)

    useEffect( () => {
        console.log("USE_EFFECT_START");

        testColumn()

        let x = JSON.parse('[{"id":1,"idoffile":"01SCYADGNAT2TT2TUGPZF3AMIF4KNILOIS","filename":"3184 Gor_Product_Category_List LIVE.xlsx","createdat":"2021-08-27T01:39:26.575137","updatedat":"2021-08-27T01:39:26.575363","worksheets":[]},{"id":2,"idoffile":"01SCYADGKGME2QYGJYXFE2IDMHAVAIUIN4","filename":"excel.xlsx","createdat":"2021-08-27T01:39:58.527421","updatedat":"2021-08-27T01:39:58.527421","worksheets":[]},{"id":3,"idoffile":"01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD","filename":"onedrive.xlsx","createdat":"2021-08-27T01:39:59.582632","updatedat":"2021-08-27T01:39:59.582633","worksheets":[]}]')
        setworkbooks(x)
        setdisplayedWorkbooks(x)
        setdisplayedWorkbooks(x)
        setapiConnect(true)

        /*fetch("https://localhost:44326/api/Workbook/GetAllWorkbooksFromDb")
        .then( response => response.json() )
        .then( response => {
            console.log(response)
            console.log(JSON.stringify(response))
            setworkbooks(response)
            setdisplayedWorkbooks(response)
            setapiConnect(true)
        }).catch(error => {

            console.log(error);
            if(error) {
                setapiConnect(false)
            }
        })*/


        const interval = setInterval(() => {
            connectService.checkConnect()
        }, 4000)

        /*return () => {
            console.log("CLEAN")
            clearInterval(interval)
        }*/

    }, [] )

    const showWorksheets = (_fileId) => {
        navigation.navigate('WorksheetsList', {fileId : _fileId, connectService} )
    }

    const filterWorkbooks = (e) => {

        setfilteredValue(e.target.value)

        let filtered = workbooks.filter(item =>
            item.name.toLowerCase().includes( e.target.value.toLowerCase() ))

        setdisplayedWorkbooks(filtered)
    }

    const disconnect = () => {
        connectService.disconnect()
    }

    const changeValue = (index) => {

        let tempDbdata = [...dbData]
        let x = {...dbData[index]}

        if(!connectService.isConnectedFunc() ) {
            connectService.addDataToCache(x)
        }

        x.value = "ZMIENIONA_WARTOSC"

        tempDbdata[index] = x
        setdbData(tempDbdata)
    }

    return (
        (connectService.isConnectedFunc() && (apiConnect)) ? (
        // <TouchableWithoutFeedback onPress={ () => { Keyboard.dismiss(); }  } >
            <View style={globalStyles.container}>
                {/* <View style={ worksheetRecord.rowContainer }>

                    <View style={worksheetRecord.columns}>
                        <View style={ worksheetRecord.listItem }>
                            <Text>x</Text>
                        </View>

                        <View style={ worksheetRecord.listItem }>
                            <Text>y</Text>
                        </View>
                    </View>

                    <View style={worksheetRecord.value}>
                        <Text>

                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value="x"
                            />

                        </Text>

                     <Text style={worksheetRecord.updateButtonContainer}>
                            UPDATE
                        </Text>

                    </View>

                </View> */}

                {/* <View style={{flexDirection: 'row'}}>

                    <Text style={{width: '90%'}}>

                        <TextInput
                            style={worksheetRecord.inputStyle}
                            //value={columnsName[1][j].value}
                            // onChange={($event) => filterContent($event)}
                            placeholder="Value.."
                        />

                    </Text>

                    <Text style={{width: '10%'}}>
                        <Button title="Update" style={{width: '100%'}} />
                    </Text>

                </View> */}

                {/* <View style={[globalStyles.content, {backgroundColor: "orange"}]}>
                    <Button onPress={() => checkConnected()} title="Check Internet Connectivity" color="#841584"/>
                </View> */}

                {/* <View style={globalStyles.header}>
                    <Text onPress={disconnect}> !!! DISCONNECT !!!</Text>
                </View> */}

                <View style={ globalStyles.content } >
                    <Text style={ globalStyles.chooseWorkbookHeader }> All Workbooks </Text>
                    <View>
                        <TextInput
                            value={ filteredValue }
                            style={ globalStyles.inputStyle }
                            placeholder="Filter.."
                            onChange={ ($event) => filterWorkbooks($event) }
                        />
                    </View>

                    <View style={ globalStyles.lists }>

                        { displayedWorkbooks.map( (item, index) =>

                            <Text key={ index } style={globalStyles.listItem} onPress={ () => showWorksheets(item.idoffile) }>
                                { item.filename }
                            </Text>

                        ) }

                    </View>

                </View>

                <StatusBar style="auto" />

            </View>

        // </TouchableWithoutFeedback>
        ) : (
            <View>
                <Text>NO CONNECTION</Text>
            </View>
            //  <NoConnectionScreen onCheck={checkConnected} />
        ))
}
