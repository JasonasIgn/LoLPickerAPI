"use strict";
/*
|--------------------------------------------------------------------------
| ConfigSeeder
|--------------------------------------------------------------------------
|
| Make use of the Factory instance to seed database with dummy data or
| make use of Lucid models directly.
|
*/

/** @type {import('@adonisjs/lucid/src/Factory')} */
const Factory = use("Factory");

class ConfigSeeder {
  async run() {
    await Factory.model("App/Models/Config").create({
      gameId: 0
    });
  }
}

module.exports = ConfigSeeder;