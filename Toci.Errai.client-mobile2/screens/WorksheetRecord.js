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
import { getProductUrl } from '../components/RequestConfig'
import ProductDetails from './Product/ProductDetails'

export default function WorksheetRecord({ route, navigation }) {

    //const [connectService] = useState( navigation.getParam('connectService') )
    const [Product, setProduct] = useState([])
    const [areas, setareas] = useState([])
    const [btnvalueHook, setbtnvalueHook] = useState("ADD")
    const [UpdatingIndex, setUpdatingIndex] = useState(null)
    const [loading, setloading] = useState(true)
    const [tempAreaquantityRow, settempAreaquantityRow] = useState({
        id: 0,
        idarea: 1,
        idproducts: 1,
        idcodesdimensions: 1,
        iduser: 1,
        quantity: "1",
        length: "",
        width: "",
        createdat: null,
        updatedat: null,
    })

    useEffect( () => {
        fetchAreas()

        fetch(getProductUrl(12)).then(response_ => {
            return response_.json()
        }).then(response_ => {
            //console.log(JSON.stringify(response_))
            //const response_ = JSON.parse('{"product":{"id":12,"idcategories":1,"idworksheet":1,"rowindex":null,"productaccountreference":"PL_3_3000_1500","description":"PL_3_3000_1500 @ 23.55Kg/m2","idcategoriesNavigation":null,"idworksheetNavigation":null,"areaquantities":[],"productoptionvalues":[],"productsizes":[],"quoteandprices":[]},"options":[],"sizes":[{"id":34,"idproducts":12,"value":"3000","name":"Length"},{"id":35,"idproducts":12,"value":"1500","name":"Width"},{"id":36,"idproducts":12,"value":"3","name":"Thickness"}],"prices":[{"idproducts":12,"price":"460","name":null,"valuation":"£/T"},{"idproducts":12,"price":"48.7485","name":null,"valuation":"£/Sht"}],"areaQuantities":[{"id":5,"idproducts":12,"idcodesdimensions":1,"idarea":15,"iduser":1,"rowindex":null,"quantity":"7","length":"","width":"","createdat":"2021-10-28T08:21:36.411771","areacode":"QB","areaname":"Quarry Front Shed","initials":"UU"},{"id":6,"idproducts":12,"idcodesdimensions":1,"idarea":15,"iduser":1,"rowindex":null,"quantity":"78","length":"","width":"","createdat":"2021-10-28T08:21:36.412839","areacode":"QB","areaname":"Quarry Front Shed","initials":"UU"},{"id":7,"idproducts":12,"idcodesdimensions":1,"idarea":15,"iduser":1,"rowindex":null,"quantity":"19","length":"","width":"","createdat":"2021-10-28T08:21:36.413893","areacode":"QB","areaname":"Quarry Front Shed","initials":"UU"}]}')
            console.log(response_)
            setProduct(response_)

            settempAreaquantityRow(prev => {
                return {  ...prev, idproducts: response_.product.id,  }
            })

            initAreaQuantities(response_)

            setloading(false)
        }).finally(x => {
            setloading(false)
        })

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
                idarea: AppUser.getIdArea(),
            }
        })

        setbtnvalueHook("ADD")
    }

    const fetchAreas = () => {

        setareas(AppUser.getAreas())

        const savedArea = AppUser.getIdArea()
        if(savedArea) {
            settempAreaquantityRow(prev => {
                return {...prev, idarea: savedArea}
            })
        }
    }

    const deleteProduct = (index_) => {
        const newProduct = Product

        newProduct.areaQuantities.splice(index_, 1)
        setProduct(newProduct)
    }

    const updateAreaQuantitiesfterRequest = async () => {
       fetch(environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByProduct/'
            + 12).then(response_ => {
            return response_.json()
        }).then(response_ => {
            console.log(response_)
            let newProduct = Product
            newProduct.areaQuantities = response_
            setProduct(prev => {return newProduct})
            WorksheetRecord()
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

            <ProductDetails product={Product?.product} />

            <WorksheetRecord_AddBtn
                tempAreaquantityRow={tempAreaquantityRow}
                btnvalueHook={btnvalueHook}
                Product={Product}
                initAreaQuantities={initAreaQuantities}
                setbtnvalueHook={setbtnvalueHook}
                updateAreaQuantitiesfterRequest={updateAreaQuantitiesfterRequest}
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
                setUpdatingIndex={setUpdatingIndex}
                areaQuantities={Product.areaQuantities}
                updateAreaQuantitiesfterRequest={setProduct}
                setAreaQuantities={setProduct}
                areas={areas}
                setbtnvalueHook={setbtnvalueHook}
                setloading={setloading}
                deleteProduct={deleteProduct}
            />

            <ProductPrices product={Product} />

            <ProductSizes product={Product} />

            {/* <WorksheetRecordData columnsName={columnsName} columnsData={columnsData} /> */}

        </ScrollView>
    )
}
