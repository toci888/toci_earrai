import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { worksheetsList } from '../styles/worksheetsListStyles'
import { Text, View, TextInput } from 'react-native'
import { modalStyles } from '../styles/modalStyles'
import { environment } from '../environment'
import { FlatList, TouchableOpacity } from 'react-native-gesture-handler'

export default function WorksheetsList({ route, navigation }) {

    const [worksheets, setworksheets] = useState([])
    const [displayedWorksheets, setdisplayedWorksheets] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)
    const [apierror, setApierror] = useState(false)

    useEffect( () => {
        apiFetch()
    }, [] )


    const apiFetch = () => {
        setloading(true)

        let tempWorkbook = environment.apiUrl + "api/Worksheet/GetAllWorksheetsFromDb"
        fetch(tempWorkbook)
        .then( response => response.json() )
        .then( response => {
            console.log(response)
            console.log(JSON.stringify(response));
            setworksheets(response)
            setdisplayedWorksheets(response)
            setloading(false)
        }).catch(error => {
            setloading(false)
            setApierror(true)
        })
    }

    const reloadApp = () => {
        setloading(true)
        setApierror(false)
        apiFetch()
    }

    const filterWorkbooks = (text) => {

        setfilteredValue(text)

        let filtered = worksheets.filter(item => item.sheetname.toLowerCase().includes( text.toLowerCase() ))

        setdisplayedWorksheets(filtered)

    }

    const showWorksheets = (_worksheetId) => {
        console.log(_worksheetId)
        navigation.navigate('WorksheetContent', {
            worksheetId : _worksheetId.id,
        } )
    }

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

    return (

        <View style={ globalStyles.content }>

            { loading && (
                <View style={modalStyles.tempContainer}>
                    <Text style={modalStyles.tempText}>Wait..</Text>
                </View>
            )}

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
                    // <TouchableOpacity>
                        <View key={ item.id } style={ worksheetsList.listItem }>

                            <Text onPress={ () => showWorksheets(item) } style={ worksheetsList.listText }>
                                { item.sheetname }
                            </Text>

                        </View>
                    // </TouchableOpacity>

                )}
            />
        </View>
    )
}
