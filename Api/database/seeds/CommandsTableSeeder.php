<?php

use Illuminate\Database\Seeder;
use App\Command;

class CommandsTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        Command::create([
            'request' => "How are you?",
            'response' => "I'm quite alright thanks for asking.",
        ]);
    }
}
