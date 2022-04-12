import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { worksheetsList } from '../styles/ProductsListStyles'
import { Text, View, TextInput, Image } from 'react-native'
import { FlatList, TouchableOpacity } from 'react-native-gesture-handler'
import { getAllWorksheetsUrl, getAreasUrl, getQuoteAndMetricUrl, getVendorsUrl } from '../shared/RequestConfig'
import AppUser from '../shared/AppUser'
import { imagesForWorksheet, imagesManager } from '../shared/ImageSelector'
import RestClient from '../shared/RestClient';
import Waiter from '../shared/Waiter'

export default function WorksheetsList({ route, navigation }) {

    const [worksheets, setworksheets] = useState([])
    const [displayedWorksheets, setdisplayedWorksheets] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)
    const [apierror, setApierror] = useState(false)

    let restClient = new RestClient();
    let waiter = Waiter(true);

    useEffect( () => {
        setloading(true);

        restClient.GET(getAllWorksheetsUrl).then(x => { setworksheets(x); setdisplayedWorksheets(x) }).catch(e => console.log(e));
        restClient.GET(getAreasUrl).then(x => { AppUser.setAreas(x); x.forEach(element => { element.name = element.name.trim(); }); AppUser.setAreas(x); }).catch(e => console.log(e)) ;
        restClient.GET(getVendorsUrl).then(x => { console.log(x.json); AppUser.setVendors(x); }).catch(e => console.log(e));
        restClient.GET(getQuoteAndMetricUrl).then(x => { AppUser.setMetrics(x); }).catch(e => console.log(e));
        
        setloading(false);
    }, [] )

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
        navigation.navigate('ProductsList', {
            worksheetId : _worksheetId.id,
            worksheetName: _worksheetId.sheetname
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
            { loading && waiter }
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
                    <View key={ item.id }
                            style={ [worksheetsList.listItem], {backgroundColor: ((item.id % 2 == 0) ? '#c8c9cf' : '#e5e5e5') , flexDirection: 'row', height: 70} }>
                        <View  style={{width: '50%', flexDirection: 'row', justifyContent: 'flex-end', alignItems: 'center'}}>
                            {
                                imagesForWorksheet[item.id].map((v,k) => {

                                    const x = imagesManager[v]?.url

                                    if(!x) return

                                    return(
                                        <View onClick={ () => showWorksheets(item) } style={{flexDirection: 'row'}} key={k}>
                                            <View style={{width: 40}}>
                                            <TouchableOpacity onPress={ () => showWorksheets(item) }>
                                                <Image
                                                    style={{height: 30, width: 30}}
                                                    source={x}
                                                />
                                            </TouchableOpacity>
                                            </View>
                                            </View>
                                    )
                                })
                            }
                        </View>
                        <View onClick={ () => showWorksheets(item) }  style={{width: '40%', flexDirection: 'row', justifyContent: 'flex-start', alignItems: 'center'}}>
                           <View>
                           <TouchableOpacity onPress={ () => showWorksheets(item) }>
                                <Text style={ [worksheetsList.listText], {fontSize: 16} }>
                                        { item.sheetname }
                                    </Text>
                            </TouchableOpacity>
                            </View>
                        {/* </TouchableOpacity> */}
                        </View>
                    </View>
                )}
            />

            {/* <View style={{position: 'fixed', bottom: 0}}  >
                <Text style={{color: 'black'}}>
                    HEJ
                </Text>

            </View> */}
        </View>
    )
}
