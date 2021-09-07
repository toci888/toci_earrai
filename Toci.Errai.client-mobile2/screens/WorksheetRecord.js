import React, { useEffect, useState } from 'react'
import { Text, View } from 'react-native'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import { environment } from '../environment'
import AppUser from '../shared/AppUser'
import WorksheetRecord_Inputs from '../components/WorksheetRecord_Inputs'
import WorksheetRecord_Grid from '../components/WorksheetRecord_Grid'
import WorksheetRecord_AddBtn from '../components/WorksheetRecord_AddBtn'
import { modalStyles } from '../styles/modalStyles'

export default function WorksheetRecord({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
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
        lengthdimensions: "",
        widthdimensions: "",
        createdat: null,
        updatedat: null,
    })

    useEffect( () => {

        connectService.setRowIndex(navigation.getParam('rowIndex') || null)

        setColumnsName(navigation.getParam('worksheetColumns'))
        const _worksheetRecords = navigation.getParam('workSheetRecord')

        setColumnsData(_worksheetRecords)

        let code = _worksheetRecords[0].value
        let code2 = _worksheetRecords[1].value

        settempAreaquantityRow( prev => {
            return {...prev,
                rowindex: _worksheetRecords[0].rowindex,
                idworksheet: connectService.getNowWorksheetId()
            }
        })
        setloading(true)
        fetch(environment.prodApiUrl + 'api/AreasQuantities/GetAreasQuantitiesByRowIndexAndWorksheet/' + _worksheetRecords[0].rowindex + '/' +connectService.getNowWorksheetId()).then(r => {
            return r.json()
        }).then(r => {
            setgridData(r)
        }).finally(x => {
            setloading(false)
        })

        AppUser.getApiData()
        .then( response => {
            response = JSON.parse(response)

            setareas(response['Areas'])

            let kind = response['Categories'].filter(item => (
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
                    idarea: response['Areas'][0]['id']
                }
            })

            let savedArea = AppUser.getIdArea()
            if(savedArea) {
                settempAreaquantityRow(prev => {
                    return {...prev, idarea: savedArea}
                })
            }
        } )

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
        })
    }

    const clearInputs = () => {
        settempAreaquantityRow(prev => {
            return {...prev,
                id: 0,
                idarea: AppUser.getIdArea() || 0,
                iduser: 3,
                quantity: "",
                lengthdimensions: "",
                widthdimensions: "",
                createdat: null,
                updatedat: null,
            }
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

            <WorksheetRecord_Inputs
                tempAreaquantityRow={tempAreaquantityRow}
                settempAreaquantityRow={settempAreaquantityRow}
                kindOfDisplay={kindOfDisplay}
                areas={areas}
            />

            <WorksheetRecord_Grid
                gridData={gridData}
                updateTableAfterRequest={updateTableAfterRequest}
                settempAreaquantityRow={settempAreaquantityRow}
                kindOfDisplay={kindOfDisplay}
                areas={areas}
                setbtnvalueHook={setbtnvalueHook}
                setloading={setloading}
            />

            {/* <WorksheetRecordData columnsName={columnsName} columnsData={columnsData} /> */}

        </View>
    )
}
