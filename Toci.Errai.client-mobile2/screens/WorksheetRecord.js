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
import ProductPrices from './Product/ProducPrices'
import ProductSizes from './Product/productSizes'

let tempQuan = [
    {createdat: "20.11.2021", updDateF: "20.11.2021",id: 1, length: 1000, width: 1000, quantity: 3,  initials: "AB",areacode: "AA", areaname: "Anon ALkoh",
    }, {  createdat: "21.11.2021", updDateF: "21.11.2021", id: 2, length: 2500, width: 1500, quantity: 6, initials: "AD",  areacode: "BB", areaname: "Bardzo bobrze", }]

export default function WorksheetRecord({ route, navigation }) {

    //const [connectService] = useState( navigation.getParam('connectService') )
    const [areas, setareas] = useState([])
    const [btnvalueHook, setbtnvalueHook] = useState("ADD")
    const [loading, setloading] = useState(true)

    const [kindOfDisplay, setkindOfDisplay] = useState(1)

    const [tempAreaquantityRow, settempAreaquantityRow] = useState({
        id: 0,
        idarea: 1,
        idworksheet: null,
        idcodesdimensions: null,
        iduser: 3,
        quantity: "",
        length: "",
        width: "",
        createdat: null,
        updatedat: null,
    })

    const [Product, setProduct] = useState([])

    useEffect( () => {

        // fetch(environment.apiUrl + 'api/Product/GetProduct/576').then(response_ => {
        //     return response_.json()
        // }).then(response_ => {
            const response_ = JSON.parse('{"product":{"id":576,"idcategories":1,"idworksheet":1,"rowindex":null,"productaccountreference":"PL_2_2500_1250","description":"PL_2_2500_1250 @ 15.7Kg/m2","idcategoriesNavigation":null,"idworksheetNavigation":null,"areaquantities":[],"productoptionvalues":[],"productsizes":[],"quoteandprices":[]},"options":[],"sizes":[{"id":1383,"idproducts":576,"value":"2500","name":"Length"},{"id":1384,"idproducts":576,"value":"1250","name":"Width"},{"id":1385,"idproducts":576,"value":"2","name":"Thickness"}],"prices":[{"idproducts":576,"price":"459","name":"PoundsPerTonne","valuation":"£/T"},{"idproducts":576,"price":"22.5196875","name":"PoundsPerSheet","valuation":"£/Sht"}],"areaQuantities":[]}')
            console.log(response_)
            response_.areaQuantities = tempQuan
            setProduct(response_)
            setloading(false)

            AppUser.getApiData()
            .then( response => {
                //console.log(response)
                setareas(response['areas'])
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

    return (
        <ScrollView style={worksheetRecord.container}>

            { loading && (
                <View style={modalStyles.tempContainer}>
                    <Text style={modalStyles.tempText}>Wait..</Text>
                </View>
            )}

            <WorksheetRecord_AddBtn
                tempAreaquantityRow={tempAreaquantityRow}
                btnvalueHook={btnvalueHook}
                updateTableAfterRequest={updateTableAfterRequest}
                clearInputs={clearInputs}
                kindOfDisplay={kindOfDisplay}
                setloading={setloading}
            />

            { btnvalueHook == "UPDATE" && (
                <WorksheetRecord_Inputs
                    settempAreaquantityRow={settempAreaquantityRow}
                    tempAreaquantityRow={tempAreaquantityRow}
                    kindOfDisplay={kindOfDisplay}
                    areas={areas}
                    setbtnvalueHook={setbtnvalueHook}
                />
            ) }

            <WorksheetRecord_Grid
                settempAreaquantityRow={settempAreaquantityRow}
                areaQuantities={Product.areaQuantities}
                updateTableAfterRequest={setProduct}
                setAreaQuantities={setProduct}
                kindOfDisplay={kindOfDisplay}
                areas={areas}
                setbtnvalueHook={setbtnvalueHook}
                setloading={setloading}
            />

            <ProductPrices product={Product} />

            <ProductSizes product={Product} />

            {/* <WorksheetRecordData columnsName={columnsName} columnsData={columnsData} /> */}

        </ScrollView>
    )
}
