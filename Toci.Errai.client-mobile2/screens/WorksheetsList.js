import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { worksheetsList } from '../styles/worksheetsListStyles'
import { Button, Text, View, TextInput, Alert, Keyboard } from 'react-native'
import AsyncStorage from '@react-native-community/async-storage'
import { environment } from '../environment'
import { FlatList } from 'react-native-gesture-handler'

export default function WorksheetsList({ route, navigation }) {

    const [connectService, setconnectService] = useState( navigation.getParam('connectService') )
    const [worksheets, setworksheets] = useState([])
    const [displayedWorksheets, setdisplayedWorksheets] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)

    useEffect( () => {
        connectService.setNowWorkbookId(navigation.getParam('workbookId'))
        setloading(true)
        let tempWorkbook = environment.prodApiUrl + "api/Workbook/GetAllWorksheetsFromDb/" + navigation.getParam('workbook')['idoffile']
        fetch(tempWorkbook)
        .then( response => response.json() )
        .then( response => {
            setworksheets(response)
            setdisplayedWorksheets(response)
            setloading(false)

        }).catch(error => {
            setworksheets(x)
            setloading(false)
        })

    }, [] )

    const filterWorkbooks = (text) => {

        setfilteredValue(text)

        let filtered = worksheets.filter(item => item.sheetname.toLowerCase().includes( text.toLowerCase() ))

        setdisplayedWorksheets(filtered)

    }

    const showWorksheets = (_worksheetId) => {
        console.log(_worksheetId)
        navigation.navigate('WorksheetContent', {
            worksheetId : _worksheetId.id,
            connectService: navigation.getParam('connectService') } )
    }

    if(loading) {
        return(
            <View style={ globalStyles.loading }>
                <Text style={ globalStyles.loadingText }>Loading..</Text>
            </View>
        )
    }

    return (

        <View style={ globalStyles.content }>

            <Text style={globalStyles.chooseWorkbookHeader}> All Worksheets </Text>

            <View>

                <TextInput
                    value={filteredValue}
                    style={globalStyles.inputStyle}
                    onChangeText={ (text) => filterWorkbooks(text) }
                    placeholder="Filter.."
                />

            </View>

            <FlatList
                keyExtractor={ (item) => item.id.toString() }
                data={displayedWorksheets}
                renderItem={ ( { item } ) => (

                    <View style={ worksheetsList.listItem } key={ item.id } >

                        <Text onPress={ () => showWorksheets(item) }>
                            { item.sheetname }
                        </Text>

                    </View>


                )}
            />
        </View>
    )
}
