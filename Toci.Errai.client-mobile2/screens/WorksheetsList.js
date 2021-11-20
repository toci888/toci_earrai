import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { worksheetsList } from '../styles/ProductsListStyles'
import { Text, View, TextInput, Image } from 'react-native'
import { modalStyles } from '../styles/modalStyles'
import { FlatList, TouchableOpacity } from 'react-native-gesture-handler'
import { getAllWorksheetsUrl, getAreasUrl, getQuoteAndMetricUrl, getVendorsUrl } from '../shared/RequestConfig'
import AppUser from '../shared/AppUser'
import { imagesManager } from '../shared/ImageSelector'

const imagesForWorksheet = {
    1: [1,2,3,4],
    2: [5,6],
    3: [15,16,17],
    4: [20, 21],
    5: [9,10],
    6: [11,12,13,14],
    7: [7,8],
    8: [18,19],
    9: [22,23,24,26],
}

export default function WorksheetsList({ route, navigation }) {

    const [worksheets, setworksheets] = useState([])
    const [displayedWorksheets, setdisplayedWorksheets] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)
    const [apierror, setApierror] = useState(false)

    useEffect( () => {

        /*const response_ = loginData

        setworksheets(response_[0])
        setdisplayedWorksheets(response_[0])


        response_[1].forEach(element => {
            element.name = element.name.trim()
        });

        AppUser.setAreas(response_[1]);
        AppUser.setVendors(response_[2]);
        AppUser.setMetrics(response_[3]); setloading(false); AppUser.setUserData(loginUserData)*/
        apiFetch()
    }, [] )


    const apiFetch = () => {
        setloading(true)

        Promise.all([
            fetch(getAllWorksheetsUrl).then(x => x.json()),
            fetch(getAreasUrl).then(x => x.json()),
            fetch(getVendorsUrl).then(x => x.json()),
            fetch(getQuoteAndMetricUrl).then(x => x.json()),
        ]).then( response_ => {
            console.log(response_)

            setworksheets(response_[0])
            setdisplayedWorksheets(response_[0])


            response_[1].forEach(element => {
                element.name = element.name.trim()
            });

            AppUser.setAreas(response_[1]);
            AppUser.setVendors(response_[2]);
            AppUser.setMetrics(response_[3]);

        }).catch((error) => { console.log(error)
        }).finally(() => { setloading(false) })

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

                    <View key={ item.id }
                    style={ [worksheetsList.listItem], {backgroundColor: ((item.id % 2 == 0) ? '#c8c9cf' : '#e5e5e5') , flexDirection: 'row', height: 70} }>
                        <TouchableOpacity onPress={ () => showWorksheets(item) }>
                        <View  style={{width: '50%', flexDirection: 'row', justifyContent: 'flex-end', alignItems: 'center'}}>

                            {
                                imagesForWorksheet[item.id].map((v,k) => {

                                    const x = imagesManager[v]?.url

                                    if(!x) return

                                    return(
                                        <View style={{flexDirection: 'row'}} key={k}>
                                            <View style={{width: 40}}>

                                                <Image
                                                    style={{height: 30, width: 30}}
                                                    source={x}
                                                />

                                            </View>
                                        </View>
                                    )
                                })
                            }

                        </View>
                        </TouchableOpacity>
                        <TouchableOpacity onPress={ () => showWorksheets(item) }>
                        <View  style={{width: '40%', flexDirection: 'row', justifyContent: 'flex-start', alignItems: 'center'}}>

                           <View>
                                <Text style={ [worksheetsList.listText], {fontSize: 16} }>
                                        { item.sheetname }
                                    </Text>
                            </View>

                        </View>
                        </TouchableOpacity>
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
