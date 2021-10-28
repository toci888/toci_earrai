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

    //const [connectService] = useState( new ConnectionService() )
    const [workbooks, setworkbooks] = useState([])
    const [displayedWorkbooks, setdisplayedWorkbooks] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(true)
    const [apierror, setApierror] = useState(false)

    useEffect( () => {
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

        let response  = {"Areas":[{"id":1,"code":"RH","name":"Rack House","areaquantities":[]},{"id":2,"code":"CO","name":"Compound","areaquantities":[]},{"id":3,"code":"BW","name":"Bottom Workshop","areaquantities":[]},{"id":4,"code":"TS","name":"Top Shed","areaquantities":[]},{"id":5,"code":"BY","name":"Back Yard","areaquantities":[]},{"id":6,"code":"FY","name":"Front Yard","areaquantities":[]},{"id":7,"code":"BP","name":"Big Press","areaquantities":[]},{"id":8,"code":"PO","name":"Porch","areaquantities":[]},{"id":9,"code":"BS","name":"Bolt Store","areaquantities":[]},{"id":10,"code":"LO","name":"Loft","areaquantities":[]},{"id":11,"code":"GY","name":"Garages","areaquantities":[]},{"id":12,"code":"BG","name":"Behind Garages","areaquantities":[]},{"id":13,"code":"81","name":"81 Dwelling House","areaquantities":[]},{"id":14,"code":"QA","name":"Quarry Left of Main Route","areaquantities":[]},{"id":15,"code":"QB","name":"Quarry Front Shed","areaquantities":[]},{"id":16,"code":"QC","name":"Quarry Back Shed","areaquantities":[]},{"id":17,"code":"QD","name":"Quarry Concrete","areaquantities":[]},{"id":18,"code":"QE","name":"Quarry Area E","areaquantities":[]},{"id":19,"code":"QF","name":"Quarry Area F","areaquantities":[]},{"id":20,"code":"QG","name":"Quarry Area G","areaquantities":[]},{"id":21,"code":"QH","name":"Quarry Area H","areaquantities":[]},{"id":22,"code":"QI","name":"Quarry Area I","areaquantities":[]},{"id":23,"code":"QJ","name":"Quarry Area J","areaquantities":[]},{"id":24,"code":"QK","name":"Quarry Area K","areaquantities":[]},{"id":25,"code":"QL","name":"Quarry Area L","areaquantities":[]},{"id":26,"code":"QM","name":"Quarry Area M","areaquantities":[]},{"id":27,"code":"empty","name":"empty","areaquantities":[]}],"Categories":[{"id":1,"code":"PL","kind":1,"areaquantities":[]},{"id":2,"code":"PLCHQ","kind":1,"areaquantities":[]},{"id":3,"code":"HD","kind":1,"areaquantities":[]},{"id":4,"code":"GS","kind":1,"areaquantities":[]},{"id":5,"code":"ALSH","kind":1,"areaquantities":[]},{"id":6,"code":"ALCHQ","kind":1,"areaquantities":[]},{"id":7,"code":"MSH","kind":1,"areaquantities":[]},{"id":8,"code":"EX_MET","kind":1,"areaquantities":[]},{"id":9,"code":"SHS","kind":2,"areaquantities":[]},{"id":10,"code":"RHS","kind":2,"areaquantities":[]},{"id":11,"code":"PFC","kind":2,"areaquantities":[]},{"id":12,"code":"UB","kind":2,"areaquantities":[]},{"id":13,"code":"UC","kind":2,"areaquantities":[]},{"id":14,"code":"IPE","kind":2,"areaquantities":[]},{"id":15,"code":"EA","kind":2,"areaquantities":[]},{"id":16,"code":"UA","kind":2,"areaquantities":[]},{"id":17,"code":"TS","kind":2,"areaquantities":[]},{"id":18,"code":"CHS","kind":2,"areaquantities":[]},{"id":19,"code":"GCHS","kind":2,"areaquantities":[]},{"id":20,"code":"FL","kind":2,"areaquantities":[]},{"id":21,"code":"FLB","kind":2,"areaquantities":[]},{"id":22,"code":"RB_BLK","kind":2,"areaquantities":[]},{"id":23,"code":"RB_BRI","kind":2,"areaquantities":[]},{"id":24,"code":"SQ_BLK","kind":2,"areaquantities":[]},{"id":25,"code":"SQ_BRI","kind":2,"areaquantities":[]},{"id":26,"code":"HB","kind":2,"areaquantities":[]},{"id":27,"code":"F_BH","kind":2,"areaquantities":[]},{"id":28,"code":"F_PB","kind":2,"areaquantities":[]},{"id":29,"code":"F_TB","kind":2,"areaquantities":[]},{"id":30,"code":"F_PS","kind":2,"areaquantities":[]},{"id":31,"code":"F_LL","kind":2,"areaquantities":[]},{"id":32,"code":"F_TS","kind":2,"areaquantities":[]},{"id":33,"code":"F_LR","kind":2,"areaquantities":[]},{"id":34,"code":"F_CF","kind":2,"areaquantities":[]},{"id":35,"code":"F_BT","kind":2,"areaquantities":[]},{"id":36,"code":"F_FT","kind":2,"areaquantities":[]},{"id":37,"code":"F_PL","kind":2,"areaquantities":[]},{"id":38,"code":"F_FLB","kind":2,"areaquantities":[]},{"id":39,"code":"F_YS","kind":2,"areaquantities":[]},{"id":40,"code":"F_SP","kind":2,"areaquantities":[]},{"id":41,"code":"PF_BH","kind":2,"areaquantities":[]},{"id":42,"code":"PF_PB","kind":2,"areaquantities":[]},{"id":43,"code":"PF_TB","kind":2,"areaquantities":[]},{"id":44,"code":"PF_PS","kind":2,"areaquantities":[]},{"id":45,"code":"PF_LL","kind":2,"areaquantities":[]},{"id":46,"code":"PF_TS","kind":2,"areaquantities":[]},{"id":47,"code":"PF_LR","kind":2,"areaquantities":[]},{"id":48,"code":"PF_CF","kind":2,"areaquantities":[]},{"id":49,"code":"PF_CA","kind":2,"areaquantities":[]},{"id":50,"code":"PF_BT","kind":2,"areaquantities":[]},{"id":51,"code":"PF_FT","kind":2,"areaquantities":[]},{"id":52,"code":"PF_PL","kind":2,"areaquantities":[]},{"id":53,"code":"PF_FLB","kind":2,"areaquantities":[]},{"id":54,"code":"PF_YS","kind":2,"areaquantities":[]},{"id":55,"code":"PF_SP","kind":2,"areaquantities":[]},{"id":56,"code":"RAM_","kind":2,"areaquantities":[]},{"id":57,"code":"PAI","kind":2,"areaquantities":[]},{"id":58,"code":"CON","kind":2,"areaquantities":[]}],"Workbooks":[{"id":1,"idoffile":"01SCYADGKLRAF75EEM35CIINVAJKLXMAHB","filename":"GEng_Stock_2021-08-31_Standard_Items_LIVE_Retrieved_3-9-2021_18_41.xlsx","createdat":"2021-09-07T21:29:21.990843","updatedat":"2021-09-07T21:29:21.990931","worksheets":[]}]}

        setloading(false)
        AppUser.setApiData(response)
        setworkbooks(response.Workbooks)
        setdisplayedWorkbooks(response.Workbooks)
        return



        fetch(environment.prodApiUrl + "api/EntityOperations/LoadData")
        .then(response => response.json())
        .then(response => {
            console.log(JSON.stringify(response))
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
