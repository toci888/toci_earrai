import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput } from 'react-native'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import AsyncStorage from '@react-native-community/async-storage'
import { environment } from '../environment'
import { DataTable } from 'react-native-paper'
import AppUser from '../shared/AppUser'
import { Picker } from '@react-native-community/picker'
import WorksheetRecordData from './WorksheetRecordData'

export default function WorksheetRecord({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    const [columnsName, setColumnsName] = useState([])
    const [columnsData, setColumnsData] = useState([])
    const [areas, setareas] = useState([])
    const [areaId, setareaId] = useState("")
    const [btnvalueHook, setbtnvalueHook] = useState("ADD")

    const [kindOfDisplay, setkindOfDisplay] = useState(null)

    const [dupa, setDupa] = useState("")

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

        connectService.setRowIndex(navigation.getParam('rowIndex') || null)

        setColumnsName(navigation.getParam('worksheetColumns'))
        const _worksheetRecords = navigation.getParam('workSheetRecord')

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

            setColumnsData(_worksheetRecords)

            code = _worksheetRecords[0].value
            code2 = _worksheetRecords[1].value

            settempAreaquantityRow( prev => {
                return {...prev,
                    rowindex: _worksheetRecords[0].rowindex,
                    idworksheet: connectService.getNowWorksheetId()
                }
            })

        }

        setDupa([])

        fetch(environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/' + _worksheetRecords[0].rowindex + '/' +connectService.getNowWorksheetId()).then(r => {
            return r.json()
        }).then(r => {
            setDupa(r)
        })

        Promise.all([
            AsyncStorage.getItem('Areas'),
            AsyncStorage.getItem('Categories'),
        ]).then( response => {

            let _areas = JSON.parse(response[0])
            let _categories = JSON.parse(response[1])
            setallCategories(_categories)
            setareas(_areas)

            let _nowArea = _areas[0]['id']
            setareaId(_nowArea)

            let kind = _categories.filter(item => (
                (item.code).trim() == code2 || ((item.code).trim() == code )))

            let tempKind = kind[0]['kind']
            setkindOfDisplay(tempKind)


            if(tempKind == 1) {
                settempAreaquantityRow(prev => {
                    return {...prev,
                        lengthdimensions: _worksheetRecords[5]['value'],
                        widthdimensions: _worksheetRecords[4]['value'],
                    }
                })

            } else {
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
            if(savedArea) {
                setareaId(savedArea)

                settempAreaquantityRow(prev => {
                    return {...prev, idarea: savedArea}
                })
            }
        } )

    }, [] )

    const setAreaFunc = (_id, index) => {
        settempAreaquantityRow(prev => {
            return {...prev, idarea: _id}
        })

        AppUser.setIdArea(_id)
    }

    const setLength = text => {
        settempAreaquantityRow(prev => {
            return {...prev, lengthdimensions: text }
        })

    }

    const setWidth = text => {
        settempAreaquantityRow(prev => {
            return {...prev, widthdimensions: text}
        })

    }

    const setAreaquantity = text => {
        settempAreaquantityRow(prev => {
            return {...prev, quantity: text}
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
            body: JSON.stringify([x])
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

        let x = JSON.parse(JSON.stringify(tempAreaquantityRow));

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
                    updateTableAfterRequest()
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
                    updateTableAfterRequest()
                })
                .catch(error => {
                    console.log(error)
                })
            } else {
                connectService.addDataToCache(x)
            }
        }
    }

    const updateTableAfterRequest = () => {
        fetch(environment.apiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/'
            + columnsData[0].rowindex + '/'
            + connectService.getNowWorksheetId()).then(r => {
            return r.json()
        }).then(r => {
            setDupa(r)
        })
    }

    const updateData = (index) => {
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

        } else {

            lengWid = foundRow.lengthdimensions.trim()
            settempAreaquantityRow(prev => {
                return {...prev,
                    lengthdimensions: lengWid,
                    widthdimensions: 0
                }
            })
        }

        let _area = areas.filter(item => item.code == foundRow['areacode'])[0]

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
    }

    const displayQuantities = () => {
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

            <View>

                <WorksheetRecordData columnsName={columnsName} columnsData={columnsData} />

            </View>

        </View>
    )
}
