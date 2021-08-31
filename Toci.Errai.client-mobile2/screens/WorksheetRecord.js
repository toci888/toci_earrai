import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput, Picker } from 'react-native'
import { animationFrames } from 'rxjs'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import AsyncStorage from '@react-native-community/async-storage'
import { environment } from '../environment'
import { DataTable } from 'react-native-paper'

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
        Idcodesdimensions: null,
        Iduser: 1,
        Quantity: "",
        Lengthdimensions: [0, 0],
        Createdat: null,
        Updatedat: null,
    })

    const [KindDimensions, setKindDimensions] = useState(null)
    const [kindOfDisplay, setkindOfDisplay] = useState(null)

    const [widthHook, setwidthHook] = useState("")
    const [dupa, setDupa] = useState("")
    const [lengthHook, setlengthHook] = useState("")

    useEffect( () => {


        // let json = await response.json();
        // console.log(json);

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

        fetch(environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/' + _worksheetRecords[0].rowindex + '/' +connectService.getNowWorksheetId()).then(r => {
            return r.json();
        }).then(r => {
            setDupa(r);
            console.log("QUANTITIES");
            console.log(r);
        })

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
                    Idcodesdimensions: kind[0]['id'],
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

    const updatePOST = () => {
        console.log("quantityHook")
        console.log(quantityHook)
        console.log("arequantityRow")
        console.log(tempAreaquantityRow)
        return
        let temp_ = {...tempAreaquantityRow }

        let lengWid
        if(kindOfDisplay == 1) {
            lengWid = tempAreaquantityRow.Lengthdimensions[0]
                        + " x "
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
                headers: {
                    Accept: 'application/json',
                    'Content-Type': 'application/json'
                },
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

    const updateData = (index) => {
        console.log(dupa[index]);

        let foundRow = dupa[index]
        let lengWid

        if(kindOfDisplay == 1) {
            let splittted = foundRow.lengthdimensions.split("x")

            lengWid = [splittted[0].trim(), splittted[1].trim()]
            setlengthHook(splittted[0].trim())
            setwidthHook(splittted[1].trim())
        } else {
            lengWid = [foundRow.lengthdimensions.trim()]
            setlengthHook(lengWid)
        }

        let _area = areas.filter(item => item.code == foundRow['areacode'])[0]
        console.log(_area)

        setareaId(_area.id)
        setquantityHook(foundRow['quantity'])


        let tempNewToAdd = {
            areacode: _area.code,
            areaname: _area.name,
            idarea: _area.id,
            idworksheet: connectService.getNowWorksheetId(),
            rowindex: foundRow['Rowindex'],
            idcodesdimensions: foundRow['Idcodedimensions'],
            iuser: foundRow['Iduser'],
            quantity: foundRow['quantity'],
            lengthdimensions: lengWid,
            createdat: "2021-08-30T17:35:56.872Z",
            updatedat: "2021-08-30T17:35:56.872Z",
        }

        console.log("tempNewTodd");
        console.log(tempNewToAdd);

        setDupa(prev => {
            return [...prev, tempNewToAdd]
        })


        settempAreaquantityRow(prev => {
            return {...prev,
                Quantity: foundRow['quantity'],
                lengthdimensions: lengWid,
                Idarea: _area.id,
            }
        })


        // updatePOST()

    }

    const deleteData = (index) => {
        console.log(dupa[index]);
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
                        </Text>
                    </View>

                </View>
            )


        }

        return respo
    }

    const displayQuantities = () => {
        console.log("ZACZYNAMY");
        console.log(dupa)
        if(dupa.length < 1) return

        let respo = []


        for(let i = 0; i < dupa.length; i++) {
            respo.push(

                <DataTable.Row key={i} style={ worksheetRecord.rowContainer }>
                    <DataTable.Cell key={i + "areacode"} style={worksheetRecord.gridShort}>
                        <Text>
                            {dupa[i].areacode}
                        </Text>
                    </DataTable.Cell>

                    <DataTable.Cell key={i + "areaname"} style={worksheetRecord.grid}>
                        <Text>
                            {dupa[i].areaname}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "createdat"} style={worksheetRecord.grid}>
                        <Text>
                            { dupa[i].createdat.substr(0, 10) }
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "lengthdimensions"} style={worksheetRecord.grid}>
                        <Text>
                            {dupa[i].lengthdimensions}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "quantity"} style={worksheetRecord.gridShort}>
                        <Text>
                            {dupa[i].quantity}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "initials"} style={worksheetRecord.gridShort}>
                        <Text>
                            {dupa[i].initials}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "update"} style={worksheetRecord.gridShort}>
                        <Text>
                            <Button title="UPDATE" onPress={() => updateData(i)} />
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "delete"} style={worksheetRecord.gridShort}>
                        <Text>
                            <Button title="DELETE" onPress={() => deleteData(i)} />
                        </Text>
                    </DataTable.Cell>
                </DataTable.Row>


            )
        }

        return respo;

        // { dupa.areacode }
        // { dupa.areaname }
        // { dupa.quantity }
        // { dupa.lengthdimensions }
        // return (
        // <View style={ worksheetRecord.rowContainer }>
        //     <View style={worksheetRecord.columns}>
        //         <View style={ worksheetRecord.listItem }>
        //             <Text>
        //                 { dupa.id }
        //                 { dupa.areacode }
        //                 { dupa.areaname }
        //                 { dupa.quantity }
        //             </Text>
        //         </View>

        //         <View style={ worksheetRecord.listItem }>
        //             <Text>
        //                 { dupa.id }
        //                 { dupa.areacode }
        //                 { dupa.areaname }
        //                 { dupa.quantity }
        //             </Text>
        //         </View>
        //     </View>

        //     <View style={worksheetRecord.value}>
        //         <Text>
        //             { dupa.id }
        //             { dupa.areacode }
        //             { dupa.areaname }
        //             { dupa.quantity }
        //         </Text>
        //         <Text>
        //             { dupa.id }
        //             { dupa.areacode }
        //             { dupa.areaname }
        //             { dupa.quantity }
        //         </Text>
        //     </View>
        // </View>
        // )
    }

    const getData = async () => {
        let r = await fetch(environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/' + _worksheetRecords[0].rowindex + '/' +connectService.getNowWorksheetId());
        return r;


    }

    const noConnectHeader = () => {
        if(connectService.isConnectedFunc()) return
        return(
            <View style={globalStyles.header} onPress={disconnect}>
                <Text style={globalStyles.headerText}>You're not connected now!</Text>
            </View>
        )
    }

    return (
        <View style={worksheetRecord.container}>

            { noConnectHeader() }

            <View style={ worksheetRecord.absoluteUpdate }>

                <Text style={worksheetRecord.updateText} onPress={updatePOST} >
                    {navigation.getParam('rowIndex') == null ? "ADD NEW RECORD" : "UPDATE" }
                </Text>
            </View>
            <View style={worksheetRecord.ComboView}>
                <Picker
                    selectedValue="Choose"
                    style={worksheetRecord.ComboPicker}
                    selectedValue={areaId}
                    onValueChange={(itemValue, itemIndex) => setAreaFunc(itemValue, itemIndex)}>
                    {
                        areas.map( (item, index) => {
                            return <Picker.Item style={worksheetRecord.CombiItem} key={index} label={item.name} value={item.id} />
                        } )
                    }

                </Picker>
            </View>

            <View>

                {
                    kindOfDisplay == 1 ?
                    (<View style={worksheetRecord.DimensionsView}>

                        <Text style={worksheetRecord.DimensionsInputContainer}>
                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={widthHook}
                                onChange={($event) => setWidth($event)}
                                placeholder="Type Length.."
                            />

                        </Text>

                        <Text style={worksheetRecord.DimensionsInputContainer}>
                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={lengthHook}
                                onChange={($event) => setLength($event)}
                                placeholder="Type Width.."
                            />

                        </Text>

                    </View>)
                    :
                    (<Text style={worksheetRecord.DimensionsInputContainer}>
                        <TextInput
                            style={worksheetRecord.inputStyle}
                            value={lengthHook}
                            onChange={($event) => setLength($event)}
                            placeholder="Type Length.."
                        />

                    </Text>)
                }

            </View>
            <View style={worksheetRecord.DimensionsView}>
                <Text style={worksheetRecord.QuantityInputContainer}>
                    <TextInput
                        style={worksheetRecord.inputStyle}
                        value={quantityHook}
                        onChange={($event) => setAreaquantity($event)}
                        placeholder="Type Quantity.."
                    />

                </Text>


            </View>
            <View>
                <DataTable style={globalStyles.tableContainer}>
                    { displayQuantities() }
                </DataTable>
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
