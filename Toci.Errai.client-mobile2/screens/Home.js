import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Text, View, TextInput, Button } from 'react-native'
import { ScrollView } from 'react-native-gesture-handler'
import { globalStyles } from '../styles/globalStyles'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import AsyncStorage from '@react-native-community/async-storage'
import { Picker } from '@react-native-community/picker'
import Header from '../components/header'
import { environment } from '../environment';
import VendorTable from '../components/VendorTable'
import AppUser from '../shared/AppUser'

export default function Home( { navigation }) {

    const [connectService, setconnectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [apiConnect, setapiConnect] = useState(false)
    const [loading, setloading] = useState(true)
    const [error, seterror] = useState("")
    const [error2, seterror2] = useState("")
    const [apiInfo, setapiInfo] = useState("")

    const test1 = () => {
        let x = AsyncStorage.getItem('Areas');
        console.log(JSON.parse(x));
        //console.log(x);
    }

    useEffect( () => {

        fetch(environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/' + 2 + '/' +connectService.getNowWorksheetId()).then(r => {
            return r.json();
        }).then(r => {
            console.log("QUANTITIES");
            console.log(r);
        })

        console.log("USE_EFFECT_START");

        setapiConnect(false)
        fetch(environment.apiUrl + "api/EntityOperations/LoadData")
        .then( response => {console.log(1); return response.json()} )
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
        .catch(error => {
            console.log(error)
            setloading(false)
            seterror(JSON.stringify(error))
            setapiInfo("CHYBA NIE LACZY API ???  ")
            //if(error) { setapiConnect(false) }
        })



        AsyncStorage.getItem('Workbooks')
        .then(response => {
            console.log(JSON.parse(response))
            return JSON.parse(response)
        })
        .then( (response) => {

            setdisplayedWorkbooks(response)


        }).catch(error => {
            console.log(error)
            seterror2(JSON.stringify(error))
            setapiInfo(prev => prev + "NIE LACZY STORAGE")
        }).finally(data => {
            setloading(false)
        })


        const interval = setInterval(() => {
            connectService.checkConnect()
        }, 6000)

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
       return (
            <View onPress={ () => test1() } >
                <Text>Loading2...</Text>
            </View>
        )
    }

    return (
        <View style={globalStyles.container}>
            <Header navigation={navigation} />
            { noConnectHeader() }



            {/* do wyswietlania bledow na telefonie */}
            <View>
                <Text>{error}</Text>
            </View>
            <View>
                <Text>{error2}</Text>
            </View>
            <View>
                <Text>{apiInfo}</Text>
            </View>



            <View>
                <Picker>
                    <Picker.Item  label="c" value="a" />
                    <Picker.Item  label="dc" value="da" />

                </Picker>
            </View>

            <View style={ globalStyles.content } >

                <Text style={ globalStyles.chooseWorkbookHeader }>
                    All Workbooks
                </Text>
                <View>
                    <VendorTable />
                </View>
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
