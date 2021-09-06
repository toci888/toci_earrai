import React from 'react'
import { DataTable } from 'react-native-paper'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import { Button, Text, View, TextInput } from 'react-native'

export default function WorksheetRecord_Grid(props) {

    const deleteData = (index) => {
        let x = props.dupa[index]

        let id_ = x['id']

        fetch(environment.prodApiUrl + "api/AreaQuantity/DeleteById?Id=" + id_, {
            method: "DELETE",
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify([x])
        })
        .then( response => {
            console.log(response)
            props.updateTableAfterRequest()
        })
        .catch(error => {
            console.log(error)
        })
    }

    const updateData = (index) => {
        let foundRow = props.dupa[index]
        let lengWid

        if(props.kindOfDisplay == 1) {
            let splittted = foundRow.lengthdimensions.split("x")

            lengWid = [splittted[0].trim(), splittted[1].trim()]

            props.settempAreaquantityRow(prev => {
                return {...prev,
                    lengthdimensions: lengWid[0],
                    widthdimensions: lengWid[1]
                }
            })

        } else {

            lengWid = foundRow.lengthdimensions.trim()
            props.settempAreaquantityRow(prev => {
                return {...prev,
                    lengthdimensions: lengWid,
                    widthdimensions: 0
                }
            })
        }

        let _area = props.areas.filter(item => item.code == foundRow['areacode'])[0]

        props.setareaId(_area.id)

        props.settempAreaquantityRow(prev => {
            return {...prev,
                id: foundRow['id'],
                quantity: foundRow['quantity'],
                idarea: _area.id,
                createdat: foundRow['createdat'],
            }
        })

        props.setbtnvalueHook("UPDATE")
    }

    const displayQuantities = () => {
        if(props.dupa.length < 1) return

        let respo = []

        for(let i = 0; i < props.dupa.length; i++) {
            respo.push(

                <DataTable.Row key={i} style={ worksheetRecord.rowContainer }>
                    <DataTable.Cell key={i + "areacode"} style={worksheetRecord.gridShort}>
                        <Text>
                            {props.dupa[i].areacode}
                        </Text>
                    </DataTable.Cell>

                    <DataTable.Cell key={i + "areaname"} style={worksheetRecord.grid}>
                        <Text>
                            {props.dupa[i].areaname}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "createdat"} style={worksheetRecord.grid}>
                        <Text>
                            { props.dupa[i].createdat?.substr(0, 10) }
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "lengthdimensions"} style={worksheetRecord.grid}>
                        <Text>
                            {props.dupa[i].lengthdimensions}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "quantity"} style={worksheetRecord.gridShort}>
                        <Text>
                            {props.dupa[i].quantity}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "initials"} style={worksheetRecord.gridShort}>
                        <Text>
                            {props.dupa[i].initials}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "update"} style={worksheetRecord.gridShort}>
                        <Text>
                            <Button title="UPD" onPress={() => updateData(i)} />
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "delete"} style={worksheetRecord.gridShort}>
                        <Text>
                            <Button title="DEL" onPress={() => deleteData(i)} />
                        </Text>
                    </DataTable.Cell>
                </DataTable.Row>


            )
        }

        return respo;

    }


    return (
        <View>
            <DataTable style={globalStyles.tableContainer}>
                { displayQuantities() }
            </DataTable>
        </View>
    )
}
