import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput, Picker } from 'react-native'
import { animationFrames } from 'rxjs'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import AsyncStorage from '@react-native-community/async-storage'
import { environment } from '../environment';

export default function WorksheetRecord({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    const [columnsName, setColumnsName] = useState([])
    const [columnsData, setColumnsData] = useState([])
    const [areas, setareas] = useState([])
    const [areaId, setareaId] = useState("")
    const [quantityHook, setquantityHook] = useState("")

    const [tempAreaquantityRow, settempAreaquantityRow] = useState({
        Idarea: null,
        Idworksheet: null,
        Rowindex: null,
        Idcodedimensions: null,
        Quantity: "",
        Lengthdimensions: [0, 0],
        Createdat: null,
        Updatedat: null,
    })

    const [KindDimensions, setKindDimensions] = useState(null)
    const [kindOfDisplay, setkindOfDisplay] = useState(null)

    const [widthHook, setwidthHook] = useState("")
    const [lengthHook, setlengthHook] = useState("")

    useEffect( () => {

        console.log("USE EFFECT")

        connectService.setRowIndex(navigation.getParam('rowIndex') || null)

        setColumnsName(navigation.getParam('worksheetColumns'))
        const _worksheetRecords = navigation.getParam('workSheetRecord')
        console.log('workSheetRecord');
        console.log(_worksheetRecords)


        let code, code2;
        if(_worksheetRecords == null) {
            const newArr = []
            for(let i=0; i < navigation.getParam('worksheetColumns')[0].length; i++) {
                newArr.push(
                    {
                        idworksheet: 1,
                        createdat: new Date().getTime(),
                        updatedat: new Date().getTime(),
                        columnindex: i,
                        rowindex: null
                    }
                )
            }
            setColumnsData(newArr)
        } else {

            let _worksheetRecords = navigation.getParam('workSheetRecord')
            setColumnsData(_worksheetRecords)
            console.log(_worksheetRecords)

            code = _worksheetRecords[0].value
            code2 = _worksheetRecords[1].value

            console.log("code")
            console.log(code)
            console.log(code2)



            settempAreaquantityRow( prev => {
                return {...prev,
                    Rowindex: _worksheetRecords[0].rowindex,
                    Idworksheet: connectService.getNowWorksheetId()
                }
            })


        }


        Promise.all([
            AsyncStorage.getItem('Areas'),
            AsyncStorage.getItem('Categories'),
        ]).then( response => {
            let _areas = JSON.parse(response[0])
            let _categories = JSON.parse(response[1])
            console.log("areas")
            console.log(_areas)
            setareas(_areas)

            console.log("categories")
            console.log(_categories)

            let kind = _categories.filter(item => (
                (item.code).trim() == code2 || ((item.code).trim() == code )))
            console.log(kind)
            setkindOfDisplay(kind[0]['kind'])



            settempAreaquantityRow(prev => {
                return {...prev,
                    Idcodedimensions: kind[0]['id'],
                }
            })






        } )

        return () => {console.log("END RECORD SCREEN ?")}
    }, [] )

    const testChangeValue = (e, index) => {
        console.log(e.target.value, index)


        let val = columnsData[index].value


        const tempContent = [...columnsData]

        //console.log(tempContent)

        tempContent[index].value = e.target.value



        setColumnsData(tempContent)
        return

    }

    const disconnect = () => {
        connectService.disconnect()
    }

    const updateValue = (index) => {

        const tempContent = columnsData[index]

        console.log(columnsData[index])
        if(!connectService.isConnectedFunc() ) {
            connectService.addDataToCache(tempContent)
        } else {
            connectService.updateRecord(tempContent)
        }
    }

    const setAreaFunc = (_id, index) => {
        console.log(_id)
        setareaId(_id)



        settempAreaquantityRow(prev => {
            return {...prev, Idarea: _id}
        })

    }

    const setLength = (e) => {

        let lengthVal = e.target.value
        console.log(lengthVal)
        setlengthHook(prev => lengthVal)

        let lengthToAdd = tempAreaquantityRow.Lengthdimensions

        lengthToAdd[0] = lengthVal

        settempAreaquantityRow(prev => {
            return {...prev, Lengthdimensions: lengthToAdd }
        })

    }

    const setWidth = (e) => {

        let widthVal = e.target.value
        console.log(widthVal);
        setwidthHook(prev => widthVal)

        let widthToAdd = tempAreaquantityRow.Lengthdimensions

        if(kindOfDisplay == 1) {
            widthToAdd[1] = widthVal
        } else {

        }

        settempAreaquantityRow(prev => {
            return {...prev, Lengthdimensions: widthToAdd}
        })

    }

    const setAreaquantity = (e) => {

        let _quantity = e.target.value

        setquantityHook( prev => _quantity )

        settempAreaquantityRow(prev => {
            return {...prev, Quantity: _quantity}
        })


        /*if(!connectService.isConnectedFunc()) {
            connectService.addDataToCache(tempContent)
        } else {

        }*/

        //console.log(tempAreaquantityRow)

    }

    const updateData = () => {
        console.log("quantityHook");
        console.log(quantityHook);
        console.log("area object");


        let temp_ = {...tempAreaquantityRow }

        let lengWid
        if(kindOfDisplay == 1) {
            lengWid = tempAreaquantityRow.Lengthdimensions[0]
                        + " vs "
                    + tempAreaquantityRow.Lengthdimensions[1]
        } else {
            lengWid = tempAreaquantityRow.Lengthdimensions[0]
        }

        temp_ = {...temp_,
            Createdat: "2021-08-30T17:35:56.872Z",
            Updatedat: "2021-08-30T17:35:56.872Z",
            Lengthdimensions: lengWid
        }


        console.log(temp_);
        if(connectService.isConnectedFunc()) {

            fetch(environment.apiUrl + "api/AreaQuantity/PostAreaQuantities", {
                method: "POST",
                body: JSON.stringify([temp_]) // arequantity
            })
            .then( response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })

        } else {
            connectService.addDataToCache(temp_)
        }

    }


    const valueOf = (value) => { return value == "" ? "Empty Value.." : value }

    const valueOfCol = (value) => { return value == "" ? "Empty Column" : value }


    const displayRow = () => {
        if(columnsName.length < 1) return

        let respo = []
        for(let i = 0; i < columnsData.length; i++) {

            respo.push(
                <View key={i} style={ worksheetRecord.rowContainer }>

                    <View style={worksheetRecord.columns}>
                        <View style={ worksheetRecord.listItem }>
                            <Text>{valueOfCol(columnsName[0][i].value)}</Text>
                        </View>

                        <View style={ worksheetRecord.listItem }>
                            <Text>{valueOfCol(columnsName[1][i].value)}</Text>
                        </View>
                    </View>

                    <View key={i + "x"} style={worksheetRecord.value}>
                        <Text>
                            {columnsData[i].value}
                            {/* <TextInput
                                style={worksheetRecord.inputStyle}
                                value={columnsData[i].value}
                                onChange={($event) => testChangeValue($event, i)}
                            /> */}

                        </Text>


                    </View>

                </View>
            )


        }

        return respo
    }

    return (
        <View style={worksheetRecord.container}>
            <View style={ worksheetRecord.absoluteUpdate }>
                <Text style={worksheetRecord.updateText} onPress={updateData} >
                    {navigation.getParam('rowIndex') == null ? "ADD NEW RECORD" : "UPDATE" }
                </Text>
            </View>
            <View>
                <Picker
                    selectedValue="Choose"
                    style={{ height: 50 }}
                    selectedValue={areaId}
                    onValueChange={(itemValue, itemIndex) => setAreaFunc(itemValue, itemIndex)}>
                    {
                        areas.map( (item, index) => {
                            return <Picker.Item key={index} label={item.name} value={item.id} />
                        } )
                    }

                </Picker>
            </View>

            <View>


                    {
                        kindOfDisplay == 1 ?
                        (<View>

                            <Text>
                                <Text>width</Text>
                                <TextInput
                                    style={worksheetRecord.inputStyle}
                                    value={widthHook}
                                    onChange={($event) => setWidth($event)}
                                />

                            </Text>

                            <Text>
                                <Text>length</Text>
                                <TextInput
                                    style={worksheetRecord.inputStyle}
                                    value={lengthHook}
                                    onChange={($event) => setLength($event)}
                                />

                            </Text>

                        </View>)
                        :
                        (<Text>
                            <Text>length</Text>
                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={lengthHook}
                                onChange={($event) => setLength($event)}
                            />

                        </Text>)
                    }


            </View>
            <View>
                <Text>Quantity</Text>
                <Text>
                    <TextInput
                        style={worksheetRecord.inputStyle}
                        value={quantityHook}
                        onChange={($event) => setAreaquantity($event)}
                    />

                </Text>


            </View>

            {/* <View style={globalStyles.header}>
                <Text onPress={ () => disconnect() }> !!! DISCONNECT !!!</Text>
            </View> */}
            <View>

                { displayRow() }

            </View>
        </View>
    )
}
