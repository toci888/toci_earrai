import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { worksheetsList } from '../styles/worksheetsListStyles'
import { Button, Text, View, TextInput, Alert, Keyboard } from 'react-native'
import AsyncStorage from '@react-native-community/async-storage'
import { environment } from '../environment'

export default function WorksheetsList({ route, navigation }) {

    const [connectService, setconnectService] = useState( navigation.getParam('connectService') )
    const [worksheets, setworksheets] = useState([])
    const [displayedWorksheets, setdisplayedWorksheets] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)

    useEffect( () => {
        connectService.setNowWorkbookId(navigation.getParam('workbookId'))
        setloading(true)

        AsyncStorage.getItem('Worksheets')
        .then(response => {
            //console.log(response);
            console.log(JSON.parse(response));
            let x = JSON.parse(response)
            return x.filter(item => item.idworkbook == navigation.getParam('workbookId'))
        })
        .then(response => {
            setworksheets(response)
            setdisplayedWorksheets(response)
            setloading(false)
        })



        /*fetch(environment.apiUrl + "api/Workbook/GetAllWorksheetsFromDb/" + navigation.getParam('workbookId'))
            .then( response => response.json() )
            .then( response => {
                console.log(response)
                //console.log(JSON.stringify(response));
                 setworksheets(response)
                setdisplayedWorksheets(response)
                setloading(false)

            }).catch(error => {
                console.log(error);

                setworksheets(x)
                setloading(false)
            })*/

        return () => { console.log("END WorksheetsList SCREEN ?") }
    }, [] )

    const filterWorkbooks = (e) => {

        console.log(e.target.value);
        setfilteredValue(e.target.value)

        let filtered = worksheets.filter(item => item.sheetname.toLowerCase().includes( e.target.value.toLowerCase() ))

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
                    onChange={ ($event) => filterWorkbooks($event) }
                    placeholder="Filter.."
                />

            </View>

            { displayedWorksheets.map( (item, index) =>
                <View style={ worksheetsList.listItem } key={ index } >

                    <Text onPress={ () => showWorksheets(item) }>
                        { item.sheetname }
                    </Text>

                </View>
            ) }

        </View>
    )
}
