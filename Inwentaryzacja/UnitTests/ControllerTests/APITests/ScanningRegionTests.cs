﻿using Inwentaryzacja.Controllers.Api;
using Inwentaryzacja.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Moq;

namespace UnitTests.ControllerTests.APITests
{
    [TestFixture]
    class ScannigRegionTests
    {
        private APIController apiController;
        [SetUp]
        public async Task Setup()
        {
            apiController = new APIController();
            await apiController.LoginUser("user1", "111");
        }
        [Test]
        public async Task getAssetsInRoomTest_CorrectId2Ass()
        {
            AssetEntity[] assetEntityArr = await apiController.getAssetsInRoom(1);

            AssetEntity[] expected = new AssetEntity[2];
            expected[0] = new AssetEntity { id = 1, type = new AssetTypeEntity { id = 1, letter = 'c', name = "komputer" } };
            expected[1] = new AssetEntity { id = 3, type = new AssetTypeEntity { id = 3, letter = 'm', name = "monitor" } };

            Assert.AreEqual(expected, assetEntityArr);
        }
        [Test]
        public async Task getAssetsInRoomTest_CorrectId4Ass()
        {
            AssetEntity[] assetEntityArr = await apiController.getAssetsInRoom(2);

            AssetEntity[] expected = new AssetEntity[4];
            expected[0] = new AssetEntity { id = 9, type = new AssetTypeEntity { id = 3, letter = 'm', name = "monitor" } };
            expected[1] = new AssetEntity { id = 10, type = new AssetTypeEntity { id = 4, letter = 'p', name = "projektor" } };
            expected[2] = new AssetEntity { id = 11, type = new AssetTypeEntity { id = 5, letter = 's', name = "stół" } };
            expected[3] = new AssetEntity { id = 12, type = new AssetTypeEntity { id = 6, letter = 't', name = "tablica" } };

            Assert.AreEqual(expected, assetEntityArr);
        }
        [TestCase(500)]
        [TestCase(123)]
        [TestCase(-1)]
        public async Task getAssetsInRoomTest_NonexistentId(int room_id)
        {
            AssetEntity[] assetEntityArr = await apiController.getAssetsInRoom(room_id);
            Assert.AreEqual(null, assetEntityArr);
        }
        [Test]
        public async Task getAssetsInRoomTest_CorrectIdNoAss()
        {
            AssetEntity[] assetEntityArr = await apiController.getAssetsInRoom(7);

            AssetEntity[] expected = new AssetEntity[0];

            Assert.AreEqual(expected, assetEntityArr);
        }
    }
}