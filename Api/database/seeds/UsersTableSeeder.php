<?php

use Illuminate\Database\Seeder;
use App\User;

class UsersTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        User::truncate();

        $faker = \Faker\Factory::create();

        $password = Hash::make('toptal');

        User::create([
            'name' => 'Administrator',
            'username' => 'administrator',
            'email' => 'admin@test.com',
            'password' => $password,
            'accountsubscription' => 1,
            'newsletter' => false,
        ]);

    }
}