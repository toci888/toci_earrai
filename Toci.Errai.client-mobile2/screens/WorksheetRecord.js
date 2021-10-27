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
    const [Product, setProduct] = useState([])
    const [areas, setareas] = useState([])
    const [btnvalueHook, setbtnvalueHook] = useState("ADD")
    const [loading, setloading] = useState(true)
    const [tempAreaquantityRow, settempAreaquantityRow] = useState({
        id: 0,
        idarea: 1,
        idworksheet: 1,
        idcodesdimensions: 1,
        iduser: 1,
        quantity: "",
        length: "",
        width: "",
        createdat: null,
        updatedat: null,
    })

    useEffect( () => {
        fetchAreas()

        // fetch(environment.apiUrl + 'api/Product/GetProduct/576').then(response_ => {
        //     return response_.json()
        // }).then(response_ => {
            const response_ = JSON.parse('{"product":{"id":576,"idcategories":1,"idworksheet":1,"rowindex":null,"productaccountreference":"PL_2_2500_1250","description":"PL_2_2500_1250 @ 15.7Kg/m2","idcategoriesNavigation":null,"idworksheetNavigation":null,"areaquantities":[],"productoptionvalues":[],"productsizes":[],"quoteandprices":[]},"options":[],"sizes":[{"id":1383,"idproducts":576,"value":"2500","name":"Length"},{"id":1384,"idproducts":576,"value":"1250","name":"Width"},{"id":1385,"idproducts":576,"value":"2","name":"Thickness"}],"prices":[{"idproducts":576,"price":"459","name":"PoundsPerTonne","valuation":"£/T"},{"idproducts":576,"price":"22.5196875","name":"PoundsPerSheet","valuation":"£/Sht"}],"areaQuantities":[]}')
            console.log(response_)
            response_.areaQuantities = tempQuan
            setProduct(response_)
            initAreaQuantities(response_)

            setloading(false)
        // }).finally(x => {
        //     setloading(false)
        // })

    }, [] )

    const initAreaQuantities = (response_) => {
        if(!response_) response_ = Product

        const tempLenWid = {length: "", width: ""}
        response_.sizes.forEach(item => {
            if(item.name == "Length") tempLenWid.length = item.value
            if(item.name == "Width") tempLenWid.width = item.value
        })

        settempAreaquantityRow(prev => {
            return {
                ...prev,
                idworksheet: response_.product.idworksheet,
                length: tempLenWid.length.toString(),
                width: tempLenWid.width.toString(),
            }
        })
    }

    const fetchAreas = () => {
        AppUser.getApiData()
        .then( response => {
            setareas(response['areas'])
        })

        const savedArea = AppUser.getIdArea()
        if(savedArea) {
            settempAreaquantityRow(prev => {
                return {...prev, idarea: savedArea}
            })
        }
    }

    const updateTableAfterRequest = () => {
        fetch(environment.prodApiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/'
            + connectService.getNowWorksheetId()).then(response_ => {
            return response_.json()
        }).then(response_ => {
            const newProduct = Product
            newProduct.areaQuantities - response_
            setProduct(newProduct)
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
                initAreaQuantities={initAreaQuantities}
                setbtnvalueHook={setbtnvalueHook}
                updateTableAfterRequest={updateTableAfterRequest}
                initAreaQuantities={initAreaQuantities}
                setloading={setloading}
            />

                <WorksheetRecord_Inputs
                    settempAreaquantityRow={settempAreaquantityRow}
                    tempAreaquantityRow={tempAreaquantityRow}
                    areas={areas}
                    setbtnvalueHook={setbtnvalueHook}
                />

            <WorksheetRecord_Grid
                settempAreaquantityRow={settempAreaquantityRow}
                areaQuantities={Product.areaQuantities}
                updateTableAfterRequest={setProduct}
                setAreaQuantities={setProduct}
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
