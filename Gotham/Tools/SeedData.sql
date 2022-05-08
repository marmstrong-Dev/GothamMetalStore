-- Metals Seed Data
INSERT INTO Metals (metalType, metalBundleSize, lastOrdered, Classificationid)
VALUES ('Gold', 12, '2022-05-07 23:18:22.5533333', 1);
INSERT INTO Metals (metalType, metalBundleSize, lastOrdered, Classificationid)
VALUES ('Copper', 24, '2022-04-17 21:12:21.4433333', 2);
INSERT INTO Metals (metalType, metalBundleSize, lastOrdered, Classificationid)
VALUES ('Tin', 100,'2022-03-21 13:18:22.5533100' ,2);
INSERT INTO Metals (metalType, metalBundleSize, lastOrdered, Classificationid)
VALUES ('Iron', 125, '2022-05-05 12:00:12.5533344', 2);
INSERT INTO Metals (metalType, metalBundleSize, lastOrdered, Classificationid)
VALUES ('Brass', 15, '2021-12-01 11:12:01.3232333', 1);
INSERT INTO Metals (metalType, metalBundleSize, lastOrdered, Classificationid)
VALUES ('Silver', 6, '2022-05-07 23:18:22.5533333', 1);
INSERT INTO Metals (metalType, metalBundleSize, lastOrdered, Classificationid)
VALUES ('Aluminum', 10, '2022-01-07 13:18:19.2133333', 2);

-- Classification Seed Data
INSERT INTO Classifications (classificationTitle, classificationDescription)
VALUES ('Precious Metals', 'Non-Construction Based Metals Used In Decorative Wares');
INSERT INTO Classifications (classificationTitle, classificationDescription)
VALUES ('Construction Metals', 'Hardened Metals Used In Costruction Projects');

-- Vendors Seed Data
INSERT INTO Vendors (vendorName, vendorCity, vendorStateTerritory, vendorCountry)
VALUES ('Starway Refineries', 'Toronto', 'Ontario', 'Canada');
INSERT INTO Vendors (vendorName, vendorCity, vendorStateTerritory, vendorCountry)
VALUES ('Michellin Masters', 'Morgantown', 'West Virginia', 'United States');
INSERT INTO Vendors (vendorName, vendorCity, vendorStateTerritory, vendorCountry)
VALUES ('Elemental Direct', 'Tampa', 'Florida', 'United States');
INSERT INTO Vendors (vendorName, vendorCity, vendorStateTerritory, vendorCountry)
VALUES ('San Diego Refining Company', 'San Diego', 'California', 'United States');

-- Orders Seed Data
INSERT INTO Orders (orderTime, orderedMetalid, orderBatchQuantity, orderVendorid)
VALUES ('2022-05-05 12:00:12.5533344', 4, 70, 1);
INSERT INTO Orders (orderTime, orderedMetalid, orderBatchQuantity, orderVendorid)
VALUES ('2022-03-21 13:18:22.5533100', 3, 50, 1);
