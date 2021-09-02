import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Text, View, TextInput, Button } from 'react-native'
import { ScrollView } from 'react-native-gesture-handler'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import AsyncStorage from '@react-native-community/async-storage'

import Header from '../components/header'
import Login from './Login'
import Register from './Register'
import { environment } from '../environment';
import VendorTable from '../components/VendorTable'

export default function Home( { navigation }) {

    const [connectService, setconnectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [apiConnect, setapiConnect] = useState(false)
    const [loading, setloading] = useState(true)

    const test1 = () => {
        let x = AsyncStorage.getItem('Areas');
        console.log(JSON.parse(x));
        //console.log(x);
    }

    useEffect( () => {

        console.log("USE_EFFECT_START");

        /*setapiConnect(false)
        fetch(environment.apiUrl + "api/EntityOperations/LoadData")
        .then( response => response.json() )
        .then( response => {

            console.log(response)
            setloading(false)
            for (const iterator in response) {
                AsyncStorage.setItem(iterator, JSON.stringify(response[iterator]));
            }

            setworkbooks(response.Workbooks)
            setdisplayedWorkbooks(response.Workbooks)
            setapiConnect(true)

        })
        .catch(error => {*/
            //console.log(error)
            setloading(false)
            //if(error) { setapiConnect(false) }

            AsyncStorage.getItem('Workbooks')
            .then(response => {
                //console.log(response);
                console.log(JSON.parse(response));
                return JSON.parse(response)
            })
            .then(response => {
                setdisplayedWorkbooks(response)
            })
            .then( () => {

                AsyncStorage.getItem('Areaquantity_cached')
                .then(response => {
                    //console.log(response)
                    let x =  JSON.parse(response)
                    console.log(x)
                    if(x) {console.log(11)} else {console.log(22)}
                })





            })
       // })


        const interval = setInterval(() => {
            connectService.checkConnect()
        }, 4000)

        return () => { console.log("END_USE_EFFECT") }
    }, [] )

    const showWorksheets = (_workbook) => {
        navigation.navigate('WorksheetsList', {
            workbookId : _workbook.id,
            workbookFileId: _workbook.idoffile,
            connectService} )
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

    const getWorkbooksFromStorage = () => {
        //console.log(x)
        //return x
    }

    const noConnectHeader = () => {
        if(connectService.isConnectedFunc()) return
        return(
            <View style={globalStyles.header} onPress={disconnect}>
                <Text style={globalStyles.headerText}>You're not connected now!</Text>
            </View>
        )
    }

    const displayWorkbooks = () => {
        return(
            <View style={ globalStyles.lists }>

            { displayedWorkbooks?.map( (item, index) =>

                <Text key={ index } style={globalStyles.listItem} onPress={ () => showWorksheets(item) }>
                    { item.filename }
                </Text>

            ) }

        </View>
        )
    }

    if(loading) {
       return(
        <View onPress={ () => test1() } >
            <Text>Loading...</Text>
        </View>
       )
    }

    return (
        <View style={globalStyles.container}>
            <Header navigation={navigation} />
            { noConnectHeader() }
            <View>
                <VendorTable />
            </View>
            <View style={ globalStyles.content } >

                <Text style={ globalStyles.chooseWorkbookHeader }>
                    All Workbooks
                </Text>

                <View>
                    <TextInput
                        value={ filteredValue }
                        style={ globalStyles.inputStyle }
                        placeholder="Filter.."
                        onChange={ ($event) => filterWorkbooks($event) }
                    />
                </View>

                { displayWorkbooks() }

            </View>

            <StatusBar style="auto" />

        </View>
    )
}
