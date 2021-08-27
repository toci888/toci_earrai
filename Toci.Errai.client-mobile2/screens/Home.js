import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Text, View, TextInput, Button } from 'react-native'
import { ScrollView } from 'react-native-gesture-handler'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'


export default function Home( { navigation }) {

    // checkConnected().then(res=> {
    //     setConnectStatus(res)
    // })

    const [connectService, setconnectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [filteredValue, setfilteredValue] = useState("")

    useEffect( () => {
        console.log("USE_EFFECT_START");

        fetch("https://localhost:44326/api/Workbook/GetAllWorkbooksFromDb")
        .then( response => response.json() )
        .then( response => {
            console.log(response)
            setworkbooks(response)
            setdisplayedWorkbooks(response)
        })


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
        connectService.isConnectedFunc() ? (
        // <TouchableWithoutFeedback onPress={ () => { Keyboard.dismiss(); }  } >
            <View style={globalStyles.container}>

                <View style={{flexDirection: 'row'}}>

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

                </View>

                {/* <View style={[globalStyles.content, {backgroundColor: "orange"}]}>
                    <Button onPress={() => checkConnected()} title="Check Internet Connectivity" color="#841584"/>
                </View> */}

                <View style={globalStyles.header}>
                    <Text onPress={disconnect}> !!! DISCONNECT !!!</Text>
                </View>

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
            <View><Text>NO CONNECTION</Text></View>
            //  <NoConnectionScreen onCheck={checkConnected} />
        ))
}
