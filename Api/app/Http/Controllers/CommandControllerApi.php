<?php

namespace App\Http\Controllers;

use App\Command;
use Illuminate\Http\Request;

class CommandControllerApi extends Controller
{
    public function show($id) {
        $command = Command::find($id);

        return $command;
    }
}
