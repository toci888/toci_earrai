import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput/*, Picker*/ } from 'react-native'
import { animationFrames } from 'rxjs'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import AsyncStorage from '@react-native-community/async-storage'
import { environment } from '../environment'
import { DataTable } from 'react-native-paper'
import AppUser from '../shared/AppUser'
import { Picker } from '@react-native-community/picker'

export default function WorksheetRecord({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    const [columnsName, setColumnsName] = useState([])
    const [columnsData, setColumnsData] = useState([])
    const [areas, setareas] = useState([])
    const [areaId, setareaId] = useState("")
    const [quantityHook, setquantityHook] = useState("")
    const [btnvalueHook, setbtnvalueHook] = useState("ADD")
    const [tempNewToUpdate, settempNewToUpdate] = useState(null)
    const [allCategories, setallCategories] = useState(null)

    const [kindOfDisplay, setkindOfDisplay] = useState(null)

    const [widthHook, setwidthHook] = useState("")
    const [dupa, setDupa] = useState("")
    const [lengthHook, setlengthHook] = useState("")

    const [tempAreaquantityRow, settempAreaquantityRow] = useState({
        id: 0,
        idarea: 0,
        idworksheet: null,
        rowindex: null,
        idcodesdimensions: null,
        iduser: AppUser.getId(),
        quantity: "",
        lengthdimensions: "",
        widthdimensions: "",
        createdat: null,
        updatedat: null,
    })


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

            //let _worksheetRecords = navigation.getParam('workSheetRecord')
            setColumnsData(_worksheetRecords)
            //console.log(_worksheetRecords)

            code = _worksheetRecords[0].value
            code2 = _worksheetRecords[1].value

            console.log("code")
            console.log(code)
            console.log(code2)






            settempAreaquantityRow( prev => {
                return {...prev,
                    rowindex: _worksheetRecords[0].rowindex,
                    idworksheet: connectService.getNowWorksheetId()
                }
            })

        }

        setDupa([])

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
            setallCategories(_categories)
            setareas(_areas)

            let _nowArea = _areas[0]['id']
            //console.log("NOW AREA SELECTED")
            //console.log(_nowArea)
            setareaId(_nowArea)


            console.log("categories")
            console.log(_categories)

            let kind = _categories.filter(item => (
                (item.code).trim() == code2 || ((item.code).trim() == code )))
            console.log(kind)

            let tempKind = kind[0]['kind']
            setkindOfDisplay(tempKind)


            if(tempKind == 1) {
                setwidthHook(_worksheetRecords[4]['value'])
                setlengthHook(_worksheetRecords[5]['value'])

                settempAreaquantityRow(prev => {
                    return {...prev,
                        lengthdimensions: _worksheetRecords[5]['value'],
                        widthdimensions: _worksheetRecords[4]['value'],


                    }
                })

            } else {
                setlengthHook(_worksheetRecords[6]['value'])

                settempAreaquantityRow(prev => {
                    return {...prev,
                        lengthdimensions: _worksheetRecords[5]['value'],
                    }
                })
            }



            settempAreaquantityRow(prev => {
                return {...prev,
                    idcodesdimensions: tempKind,
                    idarea: _nowArea
                }
            })


            let savedArea = AppUser.getIdArea()
            console.log(savedArea)
            if(savedArea) {
                console.log("SET SAVED AREA");
                setareaId(savedArea)

                settempAreaquantityRow(prev => {
                    return {...prev, idarea: savedArea}
                })

            } else {
                console.log("NOTHNIG");
            }



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
            return {...prev, idarea: _id}
        })

        AppUser.setIdArea(_id)

    }

    const setLength = (e) => {

        let lengthVal = e.target.value
        console.log(lengthVal)
        setlengthHook(prev => lengthVal)
        settempAreaquantityRow(prev => {
            return {...prev, lengthdimensions: lengthVal }
        })

    }

    const setWidth = (e) => {

        let widthVal = e.target.value
        console.log(widthVal);
        setwidthHook(prev => widthVal)
        settempAreaquantityRow(prev => {
            return {...prev, widthdimensions: widthVal}
        })

    }

    const setAreaquantity = (e) => {

        let _quantity = e.target.value

        setquantityHook( prev => _quantity )

        settempAreaquantityRow(prev => {
            return {...prev, quantity: _quantity}
        })
    }

    const deleteData = (index) => {
        let x = dupa[index]

        let id_ = x['id']

        fetch(environment.apiUrl + "api/AreaQuantity/DeleteById?Id=" + id_, {
            method: "DELETE",
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify([x]) // arequantity
        })
        .then( response => {
            console.log(response)
            updateTableAfterDELETE(id_)
        })
        .catch(error => {
            console.log(error)
        })


    }

    const sendRequest = () => {

        console.log("arequantityRow")
        console.log(tempAreaquantityRow)



        let x = JSON.stringify(tempAreaquantityRow);

        x = JSON.parse(x)


        let lengWid
        if(kindOfDisplay == 1) {
            lengWid = tempAreaquantityRow.lengthdimensions
                        + " x "
                    + tempAreaquantityRow.widthdimensions
        } else {
            lengWid = tempAreaquantityRow.lengthdimensions
        }

        x = {...x,  lengthdimensions: lengWid }

        delete x.widthdimensions

        console.log(x)



        if(widthHook == "" || lengthHook == "" || quantityHook == "") {
            console.log("jakis pusty input")
        }

        if(btnvalueHook == "ADD") {
            if(connectService.isConnectedFunc()) {

                fetch(environment.apiUrl + "api/AreaQuantity/PostAreaQuantities", {
                    method: "POST",
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify([x]) // arequantity
                })
                .then( response => {
                    console.log(response)
                    console.log("ADDED");

                    updateTableAfterPOST()

                    /*setDupa(prev => {
                        return [...prev, x]
                    })*/
                })
                .catch(error => {
                    console.log(error)
                })

            } else {
                connectService.addDataToCache(x)
            }
        } else if(btnvalueHook == "UPDATE") {

            if(connectService.isConnectedFunc()) {

                fetch(environment.apiUrl + "api/AreaQuantity/UpdateAreaQuantity", {
                    method: "PUT",
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(x) // arequantity
                })
                .then( response => {
                    console.log(response)
                    console.log("UPDATED")

                    updateTableAfterPUT()
                })
                .catch(error => {
                    console.log(error)
                })

            } else {
                connectService.addDataToCache(x)
            }

        }

    }

    const updateTableAfterPOST = () => {
        fetch(environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/'
            + columnsData[0].rowindex + '/'
            + connectService.getNowWorksheetId()).then(r => {
            return r.json();
        }).then(r => {
            setDupa(r);
            console.log("RELOAD TABLE QUANTITIES");
            console.log(r);
        })
    }



    const updateTableAfterDELETE = (id_) => {

        let x = tempAreaquantityRow['rowindex']

        let newDupa = [...dupa]

        let nowRow_ = newDupa.findIndex(item => item.id == id_)

        newDupa.splice(nowRow_, 1)

        setDupa(newDupa)

        console.log("delete row from table");
    }

    const updateTableAfterPUT = () => {
        updateTableAfterPOST()
        return

        let x = tempAreaquantityRow['rowindex']

        let newDupa = [...dupa]

        let nowRow_ = newDupa.findIndex(item => item.id == tempAreaquantityRow['id'])
            nowRow_ = newDupa[nowRow_]

        let lengWid

        //let splittted

        if(kindOfDisplay == 1) {
            //splittted = nowRow_.lengthdimensions.split("x")

            lengWid = tempAreaquantityRow.lengthdimensions
                        + " x "
                    + tempAreaquantityRow.widthdimensions
        } else {
            lengWid = tempAreaquantityRow.lengthdimensions
        }

        nowRow_['lengthdimensions'] = lengWid
        nowRow_['quantity'] = tempAreaquantityRow.quantity

        let nowCategory = areas.filter(item => item.id == tempAreaquantityRow['idarea'])
        let nowCategoryRow = nowCategory[0]



        nowRow_['areacode'] = nowCategoryRow.code
        nowRow_['areaname'] = nowCategoryRow.name

        setDupa(newDupa)

        console.log("updated row from table");

    }

    const updateData = (index) => {
        console.log(dupa[index])

        let foundRow = dupa[index]
        let lengWid

        if(kindOfDisplay == 1) {
            let splittted = foundRow.lengthdimensions.split("x")

            lengWid = [splittted[0].trim(), splittted[1].trim()]

            settempAreaquantityRow(prev => {
                return {...prev,
                    lengthdimensions: lengWid[0],
                    widthdimensions: lengWid[1]
                }
            })

            //setlengthHook()
            //setwidthHook()
        } else {

            lengWid = foundRow.lengthdimensions.trim()
            //setlengthHook(lengWid)
            settempAreaquantityRow(prev => {
                return {...prev,
                    lengthdimensions: lengWid,
                    widthdimensions: 0
                }
            })

        }

        let _area = areas.filter(item => item.code == foundRow['areacode'])[0]
        console.log(_area)

        setareaId(_area.id)

        settempAreaquantityRow(prev => {
            return {...prev,
                id: foundRow['id'],
                quantity: foundRow['quantity'],
                idarea: _area.id,
                createdat: foundRow['createdat'],
            }
        })

        setbtnvalueHook("UPDATE")
        //setquantityHook(foundRow['quantity'])


        /*let tempNewToUpdate_ = {
            id: foundRow['id'],
            areacode: _area.code,
            areaname: _area.name,
            idarea: parseInt(_area.id),
            idworksheet: connectService.getNowWorksheetId(),
            rowindex: foundRow['rowindex'],
            idcodesdimensions: foundRow['idcodesdimensions'],
            iuser: foundRow['iduser'],
            quantity: foundRow['quantity'],
            lengthdimensions: lengWid,
            createdat: "2021-08-30T17:35:56.872Z",
            updatedat: "2021-08-30T17:35:56.872Z",
        }*/

        //console.log("tempNewToAdd");
        //console.log(tempNewToUpdate_);

        //settempNewToUpdate(tempNewToUpdate_)

        /*setDupa(prev => {
            return [...prev, tempNewToUpdate_]
        })*/
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
                            { dupa[i].createdat?.substr(0, 10) }
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

    }

    const noConnectHeader = () => {
        if(connectService.isConnectedFunc()) return
        return(
            <View style={globalStyles.header} onPress={disconnect}>
                <Text style={globalStyles.headerText}>You're not connected now!</Text>
            </View>
        )
    }

    const setButtonValue = () => {
        return navigation.getParam('rowIndex') == null ? "ADD NEW RECORD" : "UPDATE"
    }

    return (
        <View style={worksheetRecord.container}>

            { noConnectHeader() }

            <View style={ worksheetRecord.absoluteUpdate }>

                <Text style={worksheetRecord.updateText} onPress={ () => sendRequest() } >
                    { btnvalueHook }
                </Text>
            </View>
            <View style={worksheetRecord.ComboView}>
                <Picker
                    selectedValue="Choose"
                    style={worksheetRecord.ComboPicker}
                    selectedValue={tempAreaquantityRow.idarea}
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

                        <Text style={worksheetRecord.DimensionsInputContainerTwo}>
                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={tempAreaquantityRow.lengthdimensions}
                                onChange={($event) => setWidth($event)}
                                placeholder="Type Length.."
                            />

                        </Text>

                        <Text style={worksheetRecord.DimensionsInputContainerTwo}>
                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={tempAreaquantityRow.widthdimensions}
                                onChange={($event) => setLength($event)}
                                placeholder="Type Width.."
                            />

                        </Text>

                    </View>)
                    :
                    (<Text style={worksheetRecord.DimensionsInputContainerOne}>
                        <TextInput
                            style={worksheetRecord.inputStyle}
                            value={tempAreaquantityRow.lengthdimensions}
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
                        value={tempAreaquantityRow.quantity}
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
