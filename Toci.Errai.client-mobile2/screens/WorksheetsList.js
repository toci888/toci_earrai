import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { worksheetsList } from '../styles/worksheetsListStyles'
import { Text, View, TextInput } from 'react-native'
import { modalStyles } from '../styles/modalStyles'
import { environment } from '../environment'
import { FlatList, TouchableOpacity } from 'react-native-gesture-handler'

export default function WorksheetsList({ route, navigation }) {

    const [connectService, setconnectService] = useState( navigation.getParam('connectService') )
    const [worksheets, setworksheets] = useState([])
    const [displayedWorksheets, setdisplayedWorksheets] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)
    const [apierror, setApierror] = useState(false)

    useEffect( () => {
        connectService.setNowWorkbookId(navigation.getParam('workbookId'))

        apiFetch()
    }, [] )


    const apiFetch = () => {
        setloading(true)

        let response = JSON.parse('[{"id":1,"idworkbook":1,"sheetname":"Category Setup","createdat":"2021-09-07T21:29:24.285509","updatedat":"2021-09-07T21:29:24.285574","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":2,"idworkbook":1,"sheetname":"FinishProds","createdat":"2021-09-07T21:29:40.608506","updatedat":"2021-09-07T21:29:40.608508","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":3,"idworkbook":1,"sheetname":"PLT & SHEET","createdat":"2021-09-07T21:31:23.408507","updatedat":"2021-09-07T21:31:23.408508","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":4,"idworkbook":1,"sheetname":"Alum","createdat":"2021-09-07T21:38:41.01586","updatedat":"2021-09-07T21:38:41.015862","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":5,"idworkbook":1,"sheetname":"Msh & Exp.Metal","createdat":"2021-09-07T21:39:22.41414","updatedat":"2021-09-07T21:39:22.414142","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":6,"idworkbook":1,"sheetname":"Chan & Bms","createdat":"2021-09-07T21:40:16.422772","updatedat":"2021-09-07T21:40:16.422775","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":7,"idworkbook":1,"sheetname":"Angles+T","createdat":"2021-09-07T21:41:46.643611","updatedat":"2021-09-07T21:41:46.643613","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":8,"idworkbook":1,"sheetname":"FLTS","createdat":"2021-09-07T21:47:30.439386","updatedat":"2021-09-07T21:47:30.439387","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":9,"idworkbook":1,"sheetname":"Tube_CHS","createdat":"2021-09-07T21:52:29.77976","updatedat":"2021-09-07T21:52:29.779762","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":10,"idworkbook":1,"sheetname":"RHS","createdat":"2021-09-07T21:57:37.566348","updatedat":"2021-09-07T21:57:37.56635","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":11,"idworkbook":1,"sheetname":"Rnds_Sqrs_HolBar","createdat":"2021-09-07T22:01:54.088062","updatedat":"2021-09-07T22:01:54.088064","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":12,"idworkbook":1,"sheetname":"Area List","createdat":"2021-09-07T22:11:13.443575","updatedat":"2021-09-07T22:11:13.443576","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]},{"id":13,"idworkbook":1,"sheetname":"Density","createdat":"2021-09-07T22:11:27.484935","updatedat":"2021-09-07T22:11:27.484937","idworkbookNavigation":null,"areaquantities":[],"quoteandprices":[],"stocks":[],"worksheetcontents":[],"worksheetcontentshistories":[]}]')

        setworksheets(response)
        setdisplayedWorksheets(response)
        setloading(false)
        return













        let tempWorkbook = environment.prodApiUrl + "api/Workbook/GetAllWorksheetsFromDb/" + navigation.getParam('workbook')['idoffile']
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
            connectService: navigation.getParam('connectService') } )
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
