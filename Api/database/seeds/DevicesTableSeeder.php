<?php

use Illuminate\Database\Seeder;
use App\Device;
use App\User;

class DevicesTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        Device::truncate();

        $users = User::all();

        foreach ($users as $user) {
            Device::create([
                'user_id' => $user->id,
                'ip' => '127.0.0.1',
            ]);
        }
    }
}
