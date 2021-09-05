import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Text, View, TextInput } from 'react-native'
import { globalStyles } from '../styles/globalStyles'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import AsyncStorage from '@react-native-community/async-storage'
import Header from '../components/header'
import { environment } from '../environment';
import AppUser from '../shared/AppUser'

export default function Home( { navigation }) {

    const [connectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)

    useEffect( () => {

        fetch(environment.prodApiUrl + "api/EntityOperations/LoadData")
        .then( response => response.json() )
        .then( response => {

            setloading(false)

            AppUser.setWorksheetsRecords(response)
            //AsyncStorage.setItem('allData', JSON.stringify(response))

            setworkbooks(response.Workbooks)
            setdisplayedWorkbooks(response.Workbooks)
        })
        .catch(error => {
            setloading(false)
            getWorkbooksFromStorage()
        })

        const interval = setInterval(() => {
            connectService.checkConnect()
        }, 6000)

    }, [] )

    const getWorkbooksFromStorage = () => {
        AsyncStorage.getItem('Workbooks')
        .then(response => {
            return JSON.parse(response)
        })
        .then( (response) => {
            setdisplayedWorkbooks(response)
            setworkbooks(response)

        }).finally(data => {
            setloading(false)
        })
    }


    const showWorksheets = (_workbook) => {

        navigation.navigate('WorksheetsList', {
            workbookId : _workbook.id,
            workbookFileId: _workbook.idoffile,
            connectService} )
    }

    const filterWorkbooks = (e) => {
        setfilteredValue(e)

        let filtered = workbooks.filter(item =>
            item.filename.toLowerCase().includes( e.toLowerCase() ))

        setdisplayedWorkbooks(filtered)
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
            <View>
                <Text>Loading2...</Text>
            </View>
        )
    }

    return (
        <View style={globalStyles.container}>
            <Header navigation={navigation} />

            { noConnectHeader() }

            <View style={ globalStyles.content } >

                <Text style={ globalStyles.chooseWorkbookHeader }>
                    All Workbooks
                </Text>

                <View>
                    <TextInput
                        value={ filteredValue }
                        style={ globalStyles.inputStyle }
                        placeholder="Filter.."
                        onChangeText={ (text) => filterWorkbooks(text) }
                    />

                </View>

                { displayWorkbooks() }

            </View>

            <StatusBar style="auto" />

        </View>
    )
}
