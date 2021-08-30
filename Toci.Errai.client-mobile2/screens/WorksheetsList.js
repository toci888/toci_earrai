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
        //setworksheets(response)
        //setdisplayedWorksheets(response)
        setloading(true)


        //let x = '[{"id":1,"idworkbook":1,"sheetname":"Category Setup","createdat":"2021-08-27T01:39:28.081057","updatedat":"2021-08-27T01:39:28.081127","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":2,"idworkbook":1,"sheetname":"PLT & SHEET","createdat":"2021-08-27T01:39:30.843409","updatedat":"2021-08-27T01:39:30.84341","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":3,"idworkbook":1,"sheetname":"Finish_Prods","createdat":"2021-08-27T01:39:36.583633","updatedat":"2021-08-27T01:39:36.583634","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":4,"idworkbook":1,"sheetname":"Alum","createdat":"2021-08-27T01:39:38.406029","updatedat":"2021-08-27T01:39:38.40603","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":5,"idworkbook":1,"sheetname":"Msh & Exp.Metal","createdat":"2021-08-27T01:39:39.650035","updatedat":"2021-08-27T01:39:39.650036","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":6,"idworkbook":1,"sheetname":"Chan & Bms","createdat":"2021-08-27T01:39:41.409489","updatedat":"2021-08-27T01:39:41.40949","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":7,"idworkbook":1,"sheetname":"Angles+T","createdat":"2021-08-27T01:39:43.082434","updatedat":"2021-08-27T01:39:43.082435","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":8,"idworkbook":1,"sheetname":"FLTS","createdat":"2021-08-27T01:39:45.283354","updatedat":"2021-08-27T01:39:45.283354","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":9,"idworkbook":1,"sheetname":"RHS","createdat":"2021-08-27T01:39:48.144525","updatedat":"2021-08-27T01:39:48.144526","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":10,"idworkbook":1,"sheetname":"Tube_CHS","createdat":"2021-08-27T01:39:50.35063","updatedat":"2021-08-27T01:39:50.35063","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":11,"idworkbook":1,"sheetname":"Rnds_Sqrs_HolBar","createdat":"2021-08-27T01:39:52.80706","updatedat":"2021-08-27T01:39:52.80706","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":12,"idworkbook":1,"sheetname":"Density","createdat":"2021-08-27T01:39:55.729568","updatedat":"2021-08-27T01:39:55.729568","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":13,"idworkbook":1,"sheetname":"OEM_Stock","createdat":"2021-08-27T01:39:57.23466","updatedat":"2021-08-27T01:39:57.234661","idworkbookNavigation":null,"worksheetcontents":[],"worksheetcontentshistories":[]}]'
        //setdisplayedWorksheets(JSON.parse(x))

        AsyncStorage.getItem('Worksheets')
        .then(response => {
            console.log(response);
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

    /*const showWorksheets = (id) => {
        console.log(id)
        fetch(environment.apiUrl + "api/WorksheetContent/searchWorksheet/"
                + id + "/" + "Alumin")

            .then( response => response.json() )
            .then( response => {
                console.log(response)
            })
    }*/

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

            {/* <View  >

                { worksheets.map( (item, index) => {
                    return <Button style={ globalStyles.item } key={ index }
                                title={ item.name } onPress={ pressHandler }
                            />
                }) }
            </View> */}

        </View>
    )
}
