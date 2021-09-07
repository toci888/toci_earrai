import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Text, View, TextInput } from 'react-native'
import { globalStyles } from '../styles/globalStyles'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import Header from '../components/header'
import { environment } from '../environment';
import AppUser from '../shared/AppUser'
import { modalStyles } from '../styles/modalStyles'

export default function Home( { navigation }) {

    const [connectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)
    const [apierror, setApierror] = useState(false)

    useEffect( () => {

        apiFetch()

        const interval = setInterval(() => {
            connectService.checkConnect()
        }, 6000)

    }, [] )

    const reloadApp = () => {
        setloading(true)
        setApierror(false)

        apiFetch()
    }

    const apiFetch = () => {
        fetch(environment.prodApiUrl + "api/EntityOperations/LoadData")
        .then(response => response.json())
        .then(response => {
            setloading(false)
            AppUser.setApiData(response)
            setworkbooks(response.Workbooks)
            setdisplayedWorkbooks(response.Workbooks)
        })
        .catch(error => {
            setloading(false)
            setApierror(true)
        })
    }

    const getWorkbooksFromStorage = () => {
        AppUser.getApiData().then(response => {
            console.log(response)
            setworkbooks(response.Workbooks)
            setdisplayedWorkbooks(response.Workbooks)
        }).catch(error => {

        })
    }


    const showWorksheets = (_workbook) => {

        navigation.navigate('WorksheetsList', {
            workbookId : _workbook.id,
            workbook : _workbook,
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

    const displayContent = () => {
        if(apierror) return(
            <View>
                <View style={globalStyles.noConnectionView}>
                    <Text style={globalStyles.noConnectionText}> NO CONNECTION </Text>
                </View>

                <View style={globalStyles.reloadView}>
                    <Text onPress={reloadApp} style={globalStyles.reloadText}> RELOAD </Text>
                </View>

            </View>
        )

        return(
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
        )
    }

    return (
        <View style={globalStyles.container}>

            { loading && (
                <View style={modalStyles.tempContainer}>
                    <Text style={modalStyles.tempText}>Wait..</Text>
                </View>
            )}

            <Header navigation={navigation} />

            { noConnectHeader() }

            { displayContent() }

            <StatusBar style="auto" />

        </View>
    )
}
