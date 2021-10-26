import React, { useEffect, useState } from 'react'
import { Text, View, ScrollView } from 'react-native'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import { environment } from '../environment'
import AppUser from '../shared/AppUser'
import WorksheetRecord_Inputs from '../components/WorksheetRecord_Inputs'
import WorksheetRecord_Grid from '../components/WorksheetRecord_Grid'
import WorksheetRecord_AddBtn from '../components/WorksheetRecord_AddBtn'
import { modalStyles } from '../styles/modalStyles'

let x = [{
    product:{
        id:1,
        idcategories:1,
        idworksheet:1,
        rowindex:null,
        productaccountreference: "PL_1_2500_1250",
        description: "PL_1_2500_1250 @ 7.85Kg/m2"
    },
    productOptions:[ {
        id:1,
        idproductsoptions:1,
        idproducts:1,
        value:"jakis_value"
    }],
    productsize:[{
        id:1,
        idsizes:1,
        idproducts:1,
        value:"jakias_value"
    }],
    productprices:[{
        id:1,
        idproducts:1,
        price:620,
        idquotesandmetric:2,
        iduser:1
    }],
    productquantities:[]
}];

export default function WorksheetRecord({ route, navigation }) {

    //const [connectService] = useState( navigation.getParam('connectService') )
    const [columnsName, setColumnsName] = useState([])
    const [columnsData, setColumnsData] = useState([])
    const [areas, setareas] = useState([])
    const [btnvalueHook, setbtnvalueHook] = useState("ADD")
    const [loading, setloading] = useState(true)

    const [kindOfDisplay, setkindOfDisplay] = useState(null)

    const [gridData, setgridData] = useState("")

    const [tempAreaquantityRow, settempAreaquantityRow] = useState({
        id: 0,
        idarea: 0,
        idworksheet: null,
        rowindex: null,
        idcodesdimensions: null,
        iduser: 3,
        quantity: "",
        length: "",
        width: "",
        createdat: null,
        updatedat: null,
    })

    const [Prices, setPrices] = useState([])
    const [Sizes, setSizes] = useState([])
    const [AreaQuantities, setAreaQuantities] = useState([])

    const setPricesFunc = (prices_) => {
        setPrices(prev => {
            return prices_
        })
    }

    const setSizesFunc = (sizes_) => {
        setSizes(prev => {
            return sizes_
        })
    }

    const setAreaQuantitiesFunc = (areaQuantities_) => {
        setAreaQuantities(prev => {
            return areaQuantities_
        })
    }

    useEffect( () => {

        fetch(environment.apiUrl + 'api/Product/GetProduct/576').then(response_ => {
            return response_.json()
        }).then(response_ => {
            console.log(response_)
            //console.log(JSON.stringify(r))
            //setgridData(r)
            setPricesFunc(response_.Prices)
            setSizesFunc(response_.Sizes)
            setAreaQuantitiesFunc(response_.AreaQuantities)
        }).finally(data => {
            setloading(false)
        })

        //connectService.setRowIndex(navigation.getParam('rowIndex') || null)

        // setColumnsName(navigation.getParam('worksheetColumns'))
        // const _worksheetRecords = navigation.getParam('workSheetRecord')
        // console.log(_worksheetRecords)
        // setColumnsData(_worksheetRecords)

        // let code = _worksheetRecords[0].value
        // let code2 = _worksheetRecords[1].value

        // settempAreaquantityRow( prev => {
        //     return {...prev,
        //         rowindex: _worksheetRecords[0].rowindex,
        //         idworksheet: 1 //connectService.getNowWorksheetId()
        //     }
        // })
        // setloading(true)

        // const response = JSON.parse('[{"id":1432,"idworksheet":4,"idcodesdimensions":1,"idarea":8,"iduser":3,"rowindex":2,"quantity":"89","length":"37","width":"89","createdat":"2021-09-07T22:39:54.325104","areacode":"PO","areaname":"Porch","initials":"PP"},{"id":1434,"idworksheet":4,"idcodesdimensions":1,"idarea":1,"iduser":3,"rowindex":2,"quantity":"44","length":"2503","width":"1253","createdat":"2021-09-08T00:17:54.502021","areacode":"RH","areaname":"Rack House","initials":"PP"}]')
        // setgridData(response)
        // setloading(false)




        /*fetch(environment.prodApiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/' + _worksheetRecords[0].rowindex + '/' +connectService.getNowWorksheetId()).then(r => {
            return r.json()
        }).then(r => {
            console.log(r)
            console.log(JSON.stringify(r))
            setgridData(r)
        }).finally(x => {
            setloading(false)
        })*/

        // AppUser.getApiData()
        // .then( response => {
        //     console.log(response)

        //     setareas(response['Areas'])

        //     let kind = response['Categories'].filter(item => (
        //         (item.code).trim() == code2 || ((item.code).trim() == code )))

        //     let tempKind = kind[0]['kind']
        //     setkindOfDisplay(tempKind)

        //     if(tempKind == 1) {
        //         settempAreaquantityRow(prev => {
        //             return {...prev,
        //                 length: _worksheetRecords[4]['value'],
        //                 width: _worksheetRecords[5]['value'],
        //             }
        //         })

        //     } else {
        //         settempAreaquantityRow(prev => {
        //             return {...prev,
        //                 length: _worksheetRecords[4]['value'],
        //             }
        //         })
        //     }

        //     settempAreaquantityRow(prev => {
        //         return {...prev,
        //             idcodesdimensions: tempKind,
        //             idarea: response['Areas'][0]['id']
        //         }
        //     })

        //     let savedArea = AppUser.getIdArea()
        //     if(savedArea) {
        //         settempAreaquantityRow(prev => {
        //             return {...prev, idarea: savedArea}
        //         })
        //     }
        // } )

    }, [] )

    const updateTableAfterRequest = () => {
        fetch(environment.prodApiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/'
            + columnsData[0].rowindex + '/'
            + connectService.getNowWorksheetId()).then(r => {
            return r.json()
        }).then(r => {
            setgridData(r)
        }).catch(error => {
            console.log(error);
        }).finally(x => {
            setloading(false)
        })
    }

    const clearInputs = () => {
        settempAreaquantityRow(prev => {
            return {...prev,
                id: 0,
                idarea: AppUser.getIdArea() || 0,
                iduser: 3,
                quantity: "",
                length: "",
                width: "",
                createdat: null,
                updatedat: null,
            }
        })
        setbtnvalueHook("ADD")
    }


    const noConnectHeader = () => {
        //if(connectService.isConnectedFunc()) return
        return(
            <View style={globalStyles.header}>
                <Text style={globalStyles.headerText}>You're not connected now!</Text>
            </View>
        )
    }

    return (
        <ScrollView style={worksheetRecord.container}>

            {/* { noConnectHeader() } */}

            { loading && (
                <View style={modalStyles.tempContainer}>
                    <Text style={modalStyles.tempText}>Wait..</Text>
                </View>
            )}

            {/* <WorksheetRecord_AddBtn
                tempAreaquantityRow={tempAreaquantityRow}
                btnvalueHook={btnvalueHook}
                updateTableAfterRequest={updateTableAfterRequest}
                clearInputs={clearInputs}
                kindOfDisplay={kindOfDisplay}
                setloading={setloading}
            /> */}

            {/* <WorksheetRecord_Inputs
                tempAreaquantityRow={tempAreaquantityRow}
                settempAreaquantityRow={settempAreaquantityRow}
                kindOfDisplay={kindOfDisplay}
                areas={areas}
            /> */}

            <WorksheetRecord_Grid
                AreaQuantities={AreaQuantities}
                updateTableAfterRequest={updateTableAfterRequest}
                setAreaQuantities={setAreaQuantities}
                kindOfDisplay={kindOfDisplay}
                areas={areas}
                setbtnvalueHook={setbtnvalueHook}
                setloading={setloading}
            />

            {/* <WorksheetRecordData columnsName={columnsName} columnsData={columnsData} /> */}

        </ScrollView>
    )
}
