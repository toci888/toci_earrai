import { StatusBar } from 'expo-status-bar'
import React, { useEffect, useState } from 'react'
import { Text, View, TextInput, TouchableOpacity } from 'react-native'
import { globalStyles } from '../styles/globalStyles'
import {ConnectionService } from '../CacheModule/CacheServiceServiceModule'
import Header from '../components/header'
import { environment } from '../environment';
import AppUser from '../shared/AppUser'
import { modalStyles } from '../styles/modalStyles'
import { worksheetsList } from '../styles/worksheetsListStyles'

export default function Home( { navigation }) {

    const [connectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)
    const [apierror, setApierror] = useState(false)

    useEffect( () => {
        // setdisplayedWorkbooks([
        //     {filename: "hehe"},
        //     {filename: "hehe2"},
        // ])
        // setloading(false)
        apiFetch()

        // const interval = setInterval(() => {
        //     connectService.checkConnect()
        // }, 6000)

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
            console.log(response)
            setloading(false)
            AppUser.setApiData(response)
            setworkbooks(response.Workbooks)
            setdisplayedWorkbooks(response.Workbooks)
        })
        .catch(error => {
            console.log(error);
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
        //if(connectService.isConnectedFunc())
        return
    }

    const displayWorkbooks = () => {
        return(
            displayedWorkbooks?.map( (item, index) =>
            <TouchableOpacity key={ index } onPress={ () => showWorksheets(item) }>
                <View style={ worksheetsList.listItem }>
                    <Text style={worksheetsList.listText}>
                        { item.filename }
                    </Text>
                </View>
            </TouchableOpacity>
        ))
    }

    const displayContent = () => {
        if(apierror) return(
            <View>
                <View style={globalStyles.noConnectionView}>
                    <Text style={globalStyles.noConnectionText}> NO CONNECTION </Text>
                </View>
                <TouchableOpacity onPress={reloadApp}>
                    <View style={globalStyles.reloadView}>
                        <Text style={globalStyles.reloadText}> RELOAD </Text>
                    </View>
                </TouchableOpacity>
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
