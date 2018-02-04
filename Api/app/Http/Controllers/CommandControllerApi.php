<?php

namespace App\Http\Controllers;

use App\Command;

class CommandControllerApi extends Controller
{
    public function index() {
        $commands = Command::all();

        return $commands;
    }

    public function show($id) {
        $command = Command::find($id);

        return $command;
    }
}
