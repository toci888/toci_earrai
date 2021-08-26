import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput, Alert, Keyboard } from 'react-native'
import { FlatList, ScrollView, TouchableOpacity, TouchableWithoutFeedback } from 'react-native-gesture-handler'
import { globalStyles, tabStyle } from '../styles/globalStyles'
import NoConnectionScreen from "./NoConnectionScreen";
//import { checkConnected } from '../routes/isConnected';
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import { DataTable } from 'react-native-paper';

let columns = ["workbookId", "workSheetName", "row", "column", "value", "EDIT"]

export default function Home( { navigation }) {

    // checkConnected().then(res=> {
    //     setConnectStatus(res)
    // })

    const [connectService, setconnectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [indexer, setIndexer] = useState(3)
    const [filteredValue, setfilteredValue] = useState("")

    useEffect( () => {
        console.log("USE_EFFECT_START");

        fetch("https://localhost:44326/api/Workbook/GetAllWorkbooks")
        .then( response => response.json() )
        .then( response => {
            console.log(response)
            setworkbooks(response.result)
            setdisplayedWorkbooks(response.result)
        })

        const interval = setInterval(() => {
            connectService.checkConnect()
        }, 6000)

        return () => clearInterval(interval)


    }, [] )

    const showWorksheets = (_id) => {
        console.log(_id)
        navigation.navigate('WorksheetsList', {id : _id} )
    }

    const filterWorkbooks = (e) => {
        console.log(e.target.value);
        setfilteredValue(e.target.value)

        let filtered = workbooks.filter(item => item.name.toLowerCase().includes( e.target.value.toLowerCase() ))

        setdisplayedWorkbooks(filtered)

    }

    const disconnect = () => {
        connectService.disconnect()
    }

    const changeValue = (index) => {
        console.log("Zmieniamy wartość");
        console.log(dbData)
        let tempDbdata = [...dbData]
        let x = {...dbData[index]}


        console.log(x)
        console.log(connectService.cacheData);
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

                            <Text key={ index } style={globalStyles.listItem} onPress={ () => showWorksheets(item.id) }>
                                { item.name }
                            </Text>

                        ) }

                    </View>

                </View>


                <StatusBar style="auto" />
                {/* <CacheModuleService></CacheModuleService> */}
            </View>

        // </TouchableWithoutFeedback>
        ) : (
            <View><Text>NO CONNECTION</Text></View>
            //  <NoConnectionScreen onCheck={checkConnected} />
        ))
}
