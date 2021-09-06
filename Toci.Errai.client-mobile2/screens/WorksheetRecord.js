import React, { useEffect, useState } from 'react'
import { Text, View } from 'react-native'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import { environment } from '../environment'
import AppUser from '../shared/AppUser'
import WorksheetRecord_Inputs from '../components/WorksheetRecord_Inputs'
import WorksheetRecord_Grid from '../components/WorksheetRecord_Grid'

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
        iduser: 3,
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

        let url2 = environment.prodApiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/' + _worksheetRecords[0].rowindex + '/' +connectService.getNowWorksheetId()

        fetch(url2).then(r => {
            return r.json()
        }).then(r => {
            setDupa(r)
        })

        AppUser.getApiData()
        .then( response => {
            response = JSON.parse(response)

            let _areas = response['Areas']
            let _categories = response['Categories']

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
                        lengthdimensions: _worksheetRecords[4]['value'],
                        widthdimensions: _worksheetRecords[5]['value'],
                    }
                })

            } else {
                settempAreaquantityRow(prev => {
                    return {...prev,
                        lengthdimensions: _worksheetRecords[4]['value'],
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


    const sendRequest = () => {

        let dataToSend = JSON.parse(JSON.stringify(tempAreaquantityRow));

        let Length_Width
        if(kindOfDisplay == 1) {
            Length_Width = tempAreaquantityRow.lengthdimensions
                        + " x "
                    + tempAreaquantityRow.widthdimensions
        } else {
            Length_Width = tempAreaquantityRow.lengthdimensions
        }

        dataToSend = {...dataToSend,  lengthdimensions: Length_Width }

        delete dataToSend.widthdimensions

        // TODO validate inputs

        if(btnvalueHook == "ADD") {
            if(connectService.isConnectedFunc()) {

                fetch(environment.prodApiUrl + "api/AreaQuantity/PostAreaQuantities", {
                    method: "POST",
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify([dataToSend]) // arequantity
                })
                .then( response => {
                    console.log(response);
                    updateTableAfterRequest()
                    clearInputs()
                })
                .catch(error => {
                    console.log(error)
                })

            } else {
                connectService.addDataToCache(dataToSend)
            }
        } else if(btnvalueHook == "UPDATE") {

            if(connectService.isConnectedFunc()) {

                fetch(environment.prodApiUrl + "api/AreaQuantity/UpdateAreaQuantity", {
                    method: "PUT",
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(dataToSend) // arequantity
                })
                .then( response => {
                    updateTableAfterRequest()
                    clearInputs()
                })
                .catch(error => {
                    console.log(error)
                })
            } else {
                connectService.addDataToCache(dataToSend)
            }
        }
    }

    const updateTableAfterRequest = () => {
        fetch(environment.prodApiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/'
            + columnsData[0].rowindex + '/'
            + connectService.getNowWorksheetId()).then(r => {
            return r.json()
        }).then(r => {
            setDupa(r)
        }).catch(error => {
            console.log(error);
        })
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
        <View style={worksheetRecord.container}>

            {/* { noConnectHeader() } */}

            <View style={ worksheetRecord.absoluteUpdate }>

                <Text style={worksheetRecord.updateText} onPress={ () => sendRequest() } >
                    { btnvalueHook }
                </Text>
            </View>

            <WorksheetRecord_Inputs
                tempAreaquantityRow={tempAreaquantityRow}
                settempAreaquantityRow={settempAreaquantityRow}
                kindOfDisplay={kindOfDisplay}
                areas={areas}
                />

            <WorksheetRecord_Grid
                dupa={dupa}
                updateTableAfterRequest={updateTableAfterRequest}
                settempAreaquantityRow={settempAreaquantityRow}
                kindOfDisplay={kindOfDisplay}
                areas={areas}
                setareaId={setareaId}
                setbtnvalueHook={setbtnvalueHook}
                />

            {/* <WorksheetRecordData columnsName={columnsName} columnsData={columnsData} /> */}

        </View>
    )
}
