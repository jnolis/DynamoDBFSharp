
open System
open System.Collections.Generic

open Amazon.DynamoDBv2
open Amazon.DynamoDBv2.DocumentModel
open Amazon.DynamoDBv2.Model;
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.



[<EntryPoint>]
let main argv = 
    let client = new AmazonDynamoDBClient()
    client.CreateTable( 
        new CreateTableRequest(
                    TableName = "Businesses",
                    ProvisionedThroughput = new ProvisionedThroughput(ReadCapacityUnits = 3L, WriteCapacityUnits = 1L),
                    KeySchema = List [new KeySchemaElement(AttributeName = "Name", KeyType = KeyType.HASH);
                                      new KeySchemaElement(AttributeName = "Id",KeyType = KeyType.RANGE)],
                    AttributeDefinitions = 
                        List [
                                new AttributeDefinition(AttributeName = "Name", AttributeType = ScalarAttributeType.S);
                                new AttributeDefinition(AttributeName = "Id", AttributeType = ScalarAttributeType.N)]
                ))
    |> ignore
    printfn "%A" argv
    0 // return an integer exit code
