import React from "react";
import { Text, View } from "react-native";
import AppUser from "../shared/AppUser";
import { productDetails as pd } from "../styles/productDetails";

export default function Product_UtilTable(props) {
  let dictionary = new Map([
    ["poundsPerTonne", "£ per tonne"],
    ["poundsPerSheet", "£ per sheet"],
    ["poundsPerSquareMeter", "£ per square meter"],
    ["poundsPerLength", "£ per length"],
    ["kgPerMeter", "Kg per meter"],
    ["totalMeters", "Total meters"],
    ["stockTakeValue", "Stock Take Value"],
    ["kgPerSqrtMeter", "Kg per Sqrt Meter"],
    ["kgPerSheet", "Kg per sheet"],
    ["totalWeight", "Total weight"],
  ]);

  const x = (param) => {
    return dictionary.get(param) ? dictionary.get(param) : param;
  };

  return (
    <View style={{ marginBottom: 15 }}>
      <View>
        <Text
          style={{
            padding: 15,
            fontSize: 17,
            width: "100%",
            textAlign: "center",
          }}
        >
          {" "}
          {props.name}{" "}
        </Text>
      </View>
      {props.details &&
        Object.keys(props.details).map((value, key) => {
          if (props.details[value] == null) return;

          return (
            <View key={key} style={pd.inlineContainer}>
              {(() => {
                if (value.includes("pound")) {
                  if (AppUser.IsAllowed(AppUser.LevelUser)) {
                    return (
                      <View style={[pd.inlineItem, pd.inlineItemLeft]}>
                        <Text style={{ textAlign: "right" }}>{x(value)}</Text>
                      </View>
                    );
                  }
                } else {
                  return (
                    <View style={[pd.inlineItem, pd.inlineItemLeft]}>
                      <Text style={{ textAlign: "right" }}>{x(value)}</Text>
                    </View>
                  );
                }
              })()}

              {(() => {
                if (value.includes("pound")) {
                  if (AppUser.IsAllowed(AppUser.LevelUser)) {
                    return (
                      <View style={[pd.inlineItem, pd.inlineItemRight]}>
                        {<Text>{"£ " + props.details[value]}</Text>}
                      </View>
                    );
                  }
                } else {
                  return (
                    <View style={[pd.inlineItem, pd.inlineItemRight]}>
                      {<Text>{props.details[value]}</Text>}
                    </View>
                  );
                }
              })()}
            </View>
          );
        })}
    </View>
  );
}
